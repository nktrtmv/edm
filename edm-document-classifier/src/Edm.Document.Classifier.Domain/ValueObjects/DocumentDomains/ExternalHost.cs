namespace Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

public readonly record struct ExternalHost
{
    public ExternalHost()
    {
        throw new InvalidOperationException("Use Parse method");
    }

    private ExternalHost(string s)
    {
        Value = s;
    }

    public string Value { get; private init; }

    public static ExternalHost Parse(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            throw new ApplicationException("Host name can't be empty");
        }

        return new ExternalHost(s);
    }
}
