namespace Edm.Entities.Approval.Workflows.GenericSubdomain;

public sealed class Audit<T>
{
    public Audit(UtcDateTime<T> createdAt, UtcDateTime<T> updatedAt)
    {
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public UtcDateTime<T> CreatedAt { get; }
    public UtcDateTime<T> UpdatedAt { get; }
}
