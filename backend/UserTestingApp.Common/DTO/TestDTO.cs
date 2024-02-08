using UserTestingApp.Entities;

namespace UserTestingApp.Common.DTO;

public class TestDTO
{
    public string Lable { get; set; } = string.Empty;
    public int MaxMark { get; set; }
    public bool isComplited { get; set; }
    public int Mark {  get; set; }
}

