using System.ComponentModel.DataAnnotations.Schema;

namespace UserTestingApp.Entities;

public class TestTask : EntityBase
{
    public string Label { get; set; } = string.Empty;

    [ForeignKey(nameof(Test))]
    public Guid TestId { get; set; }

    public Test Test { get; set; } = null!;
    public List<Option> Options { get; set; } = null!;
}