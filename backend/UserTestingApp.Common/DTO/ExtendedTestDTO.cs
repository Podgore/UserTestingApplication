namespace UserTestingApp.Common.DTO;

public class ExtendedTestDTO
{
    public Guid Id { get; set; }
    public string Lable { get; set; } = string.Empty;
    public int MaxMark { get; set; }
    public List<TestTaskDTO> Tasks { get; set; } = null!;
}
