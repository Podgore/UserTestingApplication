namespace UserTestingApp.Common.DTO;

public class UploadAnswerDTO
{
    public Guid TestId {  get; set; }
    public List<TaskAnswerDTO> TaskAnswers { get; set; } = null!;
}