namespace Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

public readonly record struct RegistryRoleName
{
    public RegistryRoleName()
    {
        throw new InvalidOperationException("Use Parse method");
    }

    private RegistryRoleName(string s)
    {
        Value = s;
    }

    public string Value { get; private init; }

    public static RegistryRoleName Parse(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            throw new ApplicationException("RegistryRoleName name can't be empty");
        }

        return new RegistryRoleName(s);
    }
}
