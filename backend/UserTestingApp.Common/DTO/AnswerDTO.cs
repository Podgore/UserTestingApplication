namespace UserTestingApp.Common.DTO;

public class AnswerDTO
{
    public Guid TestId {  get; set; }
    public List<TaskAnswerDTO> TaskAnswers { get; set; } = null!;
}