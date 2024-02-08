using System.ComponentModel.DataAnnotations.Schema;

namespace UserTestingApp.Entities;

public class UserAnswer : EntityBase
{
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(Option))]
    public Guid OptionId { get; set; }

    [ForeignKey(nameof(TestTask))]
    public Guid TestTaskId { get; set; }

    public TestTask TestTask { get; set; } = null!;
    public User User { get; set; } = null!;
    public Option Option { get; set; } = null!;
}