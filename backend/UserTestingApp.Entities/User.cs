namespace UserTestingApp.Entities;

public class User : EntityBase
{
    public string Email { get; set; } = string.Empty;

    public List<TestUser> TestUsers { get; set; } = null!;
    public List<UserAnswer> Answers { get; set; } = null!;
}