namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects;

public readonly record struct SystemName
{
    public SystemName()
    {
        throw new InvalidOperationException("Use Parse method");
    }

    private SystemName(string s)
    {
        Value = s;
    }

    public string Value { get; private init; }

    public static SystemName Parse(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            throw new ApplicationException("SystemName name can't be empty");
        }

        return new SystemName(s);
    }

    public static implicit operator string(SystemName domainId)
    {
        return domainId.Value;
    }

    public override string ToString()
    {
        return Value;
    }
}
