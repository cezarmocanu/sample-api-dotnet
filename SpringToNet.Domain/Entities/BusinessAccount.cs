namespace SpringToNet.Domain.Entities;

/// <summary>
/// Simple business entity with name and value - Clean and minimal
/// </summary>
public class BusinessAccount
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required decimal Value { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public override string ToString() => $"{Name}: {Value:C}";
}
