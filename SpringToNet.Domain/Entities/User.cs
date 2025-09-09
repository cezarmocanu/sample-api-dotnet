namespace SpringToNet.Domain.Entities;

/// <summary>
/// Simple user entity with just a name
/// </summary>
public class User
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public override string ToString() => Name;
}
