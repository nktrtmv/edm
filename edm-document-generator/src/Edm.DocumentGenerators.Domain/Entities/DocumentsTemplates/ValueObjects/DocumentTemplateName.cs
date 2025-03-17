using Generator.Equals;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;

[Equatable]
public readonly partial record struct DocumentTemplateName
{
    public DocumentTemplateName()
    {
        throw new InvalidOperationException("Use Parse method");
    }

    private DocumentTemplateName(string s)
    {
        Value = s;
    }

    public string Value { get; private init; }

    public static DocumentTemplateName Parse(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            throw new ApplicationException("DocumentTemplateName name can't be empty");
        }

        return new DocumentTemplateName(s);
    }
}
