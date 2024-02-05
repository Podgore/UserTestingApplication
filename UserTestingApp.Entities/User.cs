namespace UserTestingApp.Entities;

public class User : EntityBase
{
    public string Email { get; set; } = string.Empty;

    public List<Test> Tests { get; set; } = null!;
}