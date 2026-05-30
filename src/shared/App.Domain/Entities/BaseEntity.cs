namespace App.Domain.Entities;

public class BaseEntity
{
    public Guid Id { get; set; }
    protected DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
