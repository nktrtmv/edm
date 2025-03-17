namespace Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

public readonly record struct DocumentRoleName
{
    public DocumentRoleName()
    {
        throw new InvalidOperationException("Use Parse method");
    }

    private DocumentRoleName(string s)
    {
        Value = s;
    }

    public string Value { get; private init; }

    public static DocumentRoleName Parse(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            throw new ApplicationException("DocumentRoleName name can't be empty");
        }

        return new DocumentRoleName(s);
    }
}
