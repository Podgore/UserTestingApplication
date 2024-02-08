using System.ComponentModel.DataAnnotations;

namespace UserTestingApp.Entities;

public abstract class EntityBase
{
    [Key]
    public Guid Id { get; set; }
}