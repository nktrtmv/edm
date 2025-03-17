namespace Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

public readonly record struct UrlAlias
{
    public UrlAlias()
    {
        throw new InvalidOperationException("Use Parse method");
    }

    private UrlAlias(string s)
    {
        Value = s;
    }

    public string Value { get; private init; }

    public static UrlAlias Parse(string s)
    {
        var result = ParseOrNull(s);

        if (result is not { } value)
        {
            throw new ApplicationException("UrlAlias can't be empty");
        }

        return value;
    }

    public static UrlAlias? ParseOrNull(string? s)
    {
        if (!IsValid(s))
        {
            return null;
        }

        return new UrlAlias(s!);
    }

    public static bool IsValid(string? s)
    {
        return !string.IsNullOrWhiteSpace(s);
    }
}
