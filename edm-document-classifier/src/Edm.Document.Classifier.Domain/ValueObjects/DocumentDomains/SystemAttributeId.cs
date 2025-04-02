namespace Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

public readonly record struct SystemAttributeId
{
    public SystemAttributeId()
    {
        throw new InvalidOperationException("Use Parse method");
    }

    private SystemAttributeId(string s)
    {
        Value = s;
    }

    public string Value { get; private init; }

    public static SystemAttributeId Parse(int n)
    {
        if (n <= 0)
        {
            throw new ApplicationException("SystemAttributeId can't be <= 0");
        }

        var idGuid = new Guid(n, 0, 0, new byte[8]);

        return new SystemAttributeId(idGuid.ToString());
    }
}
