namespace UserTestingApp.Entities;

public class Test : EntityBase
{
    string Lable { get; set; } = string.Empty;
    int MaxMark { get; set; }

    List<User> Users { get; set; } = null!;
    List<TestTask> Tasks { get; set; } = null!;
}