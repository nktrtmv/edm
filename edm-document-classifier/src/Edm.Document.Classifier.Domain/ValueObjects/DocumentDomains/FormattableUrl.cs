namespace Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

public readonly record struct FormattableUrl
{
    public FormattableUrl()
    {
        throw new InvalidOperationException("Use Parse method");
    }

    private FormattableUrl(string s)
    {
        Value = s;
    }

    public string Value { get; private init; }

    public static FormattableUrl Parse(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            throw new ApplicationException("FormattableUrl name can't be empty");
        }

        if (!s.StartsWith("{Host}"))
        {
            throw new ApplicationException("FormattableUrl must starp with {Host}");
        }

        return new FormattableUrl(s);
    }
}
