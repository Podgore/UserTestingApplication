using System.ComponentModel.DataAnnotations.Schema;

namespace UserTestingApp.Entities;

public class UserAnswer : EntityBase
{
    public int Mark { get; set; }

    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }

    public User User { get; set; } = null!;
    public List<Option> Options { get; set; } = null!;
}