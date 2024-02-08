using UserTestingApp.Common.DTO;

namespace UserTestingApp.BLL.Services.Interfaces;

public interface ITestService
{
    Task<ResultDTO> CheckTestAnswerAsync(Guid userId, AnswerDTO dto);
    Task<List<TestDTO>> GetAllTestsAsync(Guid userId);
    Task<TestDTO> GetTestAsync(Guid testId);
}
