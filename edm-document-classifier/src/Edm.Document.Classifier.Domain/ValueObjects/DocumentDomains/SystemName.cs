namespace Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

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
        var result = ParseOrNull(s);

        if (result is not { } value)
        {
            throw new ApplicationException("SystemName can't be empty");
        }

        return value;
    }

    public static SystemName? ParseOrNull(string s)
    {
        if (!IsValid(s))
        {
            return null;
        }

        return new SystemName(s);
    }

    private static bool IsValid(string s)
    {
        return !string.IsNullOrWhiteSpace(s);
    }
}
