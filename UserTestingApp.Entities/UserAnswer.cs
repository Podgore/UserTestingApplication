using System.ComponentModel.DataAnnotations.Schema;

namespace UserTestingApp.Entities;

public class UserAnswer : EntityBase
{
    int Mark { get; set; }

    [ForeignKey(nameof(User))]
    Guid UserId { get; set; }

    User User { get; set; } = null!;
    List<Option> Options { get; set; } = null!;
}