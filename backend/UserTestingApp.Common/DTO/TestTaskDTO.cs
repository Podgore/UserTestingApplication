namespace UserTestingApp.Common.DTO;

public class TestTaskDTO
{
    public Guid Id { get; set; }
    public string Label { get; set; } = string.Empty;
    public List<OptionDTO> Options { get; set; } = null!;
}
