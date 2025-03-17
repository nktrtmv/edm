namespace Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

public readonly record struct EntityType
{
    public EntityType()
    {
        throw new InvalidOperationException("Use Parse method");
    }

    private EntityType(string s)
    {
        Value = s;
    }

    public string Value { get; private init; }

    public static EntityType Parse(string s)
    {
        if (s == null)
        {
            throw new ApplicationException("EntityType name can't be empty");
        }

        return new EntityType(s);
    }
}
