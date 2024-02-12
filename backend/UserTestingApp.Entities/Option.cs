using System.ComponentModel.DataAnnotations.Schema;

namespace UserTestingApp.Entities;

public class Option : EntityBase
{
    public string Label { get; set; } = string.Empty;
    public bool IsComplited { get; set; }

    [ForeignKey(nameof(Task))]
    public Guid TaskId { get; set; }

    public TestTask Task { get; set; } = null!;    
}