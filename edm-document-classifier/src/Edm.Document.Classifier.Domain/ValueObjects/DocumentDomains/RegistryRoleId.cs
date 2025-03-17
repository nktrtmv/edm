namespace Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

public readonly record struct RegistryRoleId
{
    public RegistryRoleId()
    {
        throw new InvalidOperationException("Use Parse method");
    }

    private RegistryRoleId(int n)
    {
        Value = n;
    }

    public int Value { get; private init; }

    public static RegistryRoleId Parse(int n)
    {
        if (n <= 0)
        {
            throw new ApplicationException("RegistryRoleId can't be <= 0");
        }

        return new RegistryRoleId(n);
    }
}
