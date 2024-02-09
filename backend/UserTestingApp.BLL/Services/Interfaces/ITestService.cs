using UserTestingApp.Common.DTO;

namespace UserTestingApp.BLL.Services.Interfaces;

public interface ITestService
{
    Task<TestResultDTO> CheckTestAnswerAsync(Guid userId, AnswerDTO dto);
    Task<List<TestDTO>> GetAllTestsAsync(Guid userId);
    Task<ExtendedTestDTO> GetTestAsync(Guid testId);
}
