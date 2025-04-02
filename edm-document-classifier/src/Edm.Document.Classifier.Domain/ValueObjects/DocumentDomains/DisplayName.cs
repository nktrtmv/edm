namespace Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

public readonly record struct DisplayName
{
    public DisplayName()
    {
        throw new InvalidOperationException("Use Parse method");
    }

    private DisplayName(string s)
    {
        Value = s;
    }

    public string Value { get; private init; }

    public static DisplayName Parse(string s)
    {
        if (s == null)
        {
            throw new ApplicationException("DisplayName name can't be empty");
        }

        return new DisplayName(s);
    }
}
