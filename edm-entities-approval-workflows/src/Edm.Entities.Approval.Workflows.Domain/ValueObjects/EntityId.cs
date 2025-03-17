namespace Edm.Entities.Approval.Workflows.Domain.ValueObjects;

public readonly record struct EntityId
{
    public EntityId()
    {
        throw new InvalidOperationException("Use Parse method");
    }

    private EntityId(string s)
    {
        Value = s;
    }

    public string Value { get; private init; }

    public static EntityId Parse(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            throw new ApplicationException("EntityId name can't be empty");
        }

        return new EntityId(s);
    }

    public static implicit operator string(EntityId entityId)
    {
        return entityId.Value;
    }

    public override string ToString()
    {
        return Value;
    }
}
