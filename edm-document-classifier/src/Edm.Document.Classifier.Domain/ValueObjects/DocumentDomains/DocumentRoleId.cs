namespace Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

public readonly record struct DocumentRoleId
{
    public DocumentRoleId()
    {
        throw new InvalidOperationException("Use Parse method");
    }

    private DocumentRoleId(int n)
    {
        Value = n;
    }

    public int Value { get; private init; }

    public static DocumentRoleId Parse(int n)
    {
        if (n <= 0)
        {
            throw new ApplicationException("DocumentRoleId can't be <= 0");
        }

        return new DocumentRoleId(n);
    }
}
