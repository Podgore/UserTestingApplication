using System.ComponentModel.DataAnnotations.Schema;

namespace UserTestingApp.Entities;

public class TestUser : EntityBase
{
    public bool IsComplited { get; set; }
    public int Mark { get; set; }

    [ForeignKey(nameof(Test))]
    public Guid TestId { get; set; }

    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }

    public User User { get; set; } = null!;
    public Test Test { get; set; } = null!;
}
