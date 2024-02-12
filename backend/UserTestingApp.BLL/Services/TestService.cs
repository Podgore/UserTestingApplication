using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserTestingApp.BLL.Services.Interfaces;
using UserTestingApp.Common.DTO;
using UserTestingApp.Common.Exceptions;
using UserTestingApp.Common.Extensions;
using UserTestingApp.DAL.Repository.Interface;
using UserTestingApp.Entities;

namespace UserTestingApp.BLL.Services;

public class TestService : ITestService
{
    private readonly IRepository<Test> _testRepository;
    private readonly IRepository<TestUser> _testUsersRepository;
    private readonly IRepository<UserAnswer> _userAnswerRepository;
    private readonly IMapper _mapper;

    public TestService(
        IRepository<Test> testRepository,
        IRepository<TestUser> testUsersRepository,
        IRepository<UserAnswer> userAnswerRepository,
        IMapper mapper)
    {
        _testRepository = testRepository;
        _testUsersRepository = testUsersRepository;
        _userAnswerRepository = userAnswerRepository;
        _mapper = mapper;
    }

    public async Task<List<TestDTO>> GetAllTestsAsync(Guid userId)
    {
        var tests = await _testRepository
            .Include(t => t.TestUsers)
            .Where(t => t.TestUsers.Any(tu => tu.UserId == userId))
            .ToListAsync();

        return tests.Select(test =>
        {
            var dto = _mapper.Map<TestDTO>(test)!;
            var testUser = test.TestUsers.FirstOrDefault(tu => tu.UserId == userId);

            dto.Mark = testUser?.Mark ?? 0;
            dto.isComplited = testUser?.IsComplited ?? false;

            return dto;
        }).ToList()!;
    }

    public async Task<ExtendedTestDTO> GetTestAsync(Guid testId)
    {
        var test = await _testRepository.Include(t => t.Tasks).ThenInclude(task => task.Options).FirstOrDefaultAsync(t => t.Id == testId)
            ?? throw new NotFoundException($"Test with this Id is not exist: {testId}");

        return _mapper.Map<ExtendedTestDTO>(test)!;
    }

    public async Task<TestResultDTO> CheckTestAnswerAsync(Guid userId, UploadAnswerDTO dto)
    {
        var test = await _testRepository
            .Include(t => t.TestUsers)
            .Include(t => t.Tasks)
            .ThenInclude(tt => tt.Options)
            .FirstOrDefaultAsync(t => t.Id == dto.TestId)
                ?? throw new NotFoundException($"Test with this id doesn't exist: {dto.TestId}");

        var userTest = test.TestUsers.FirstOrDefault(tu => tu.UserId == userId)
            ?? throw new NotFoundException($"This test doesn`t assignet to the user with this Id: {userId}");

        if (userTest.IsComplited)
            throw new InvalidOperationException("Unable to upload answers to already completed test");

        var mark = dto.TaskAnswers.Count(t => test.Tasks.FirstOrDefault(tt => tt.Id == t.TestTaskId)?.Compare(t) ?? false);

        userTest.Mark = (int)(mark * 1.0D / test.Tasks.Count * test.MaxMark);

        userTest.IsComplited = true;

        await _testUsersRepository.UpdateAsync(userTest);

        foreach (var answer in dto.TaskAnswers)
        {
            var result = _mapper.Map<UserAnswer>(answer);

            result!.UserId = userId;

            await _userAnswerRepository.InsertAsync(result);
        }

        return new TestResultDTO(userTest.Mark);
    }
}