namespace Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

public readonly record struct DomainName
{
    public DomainName()
    {
        throw new InvalidOperationException("Use Parse method");
    }

    private DomainName(string s)
    {
        Value = s;
    }

    public string Value { get; private init; }

    public static DomainName Parse(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            throw new ApplicationException("DomainName name can't be empty");
        }

        return new DomainName(s);
    }
}
