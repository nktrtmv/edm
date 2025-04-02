namespace Edm.Document.Classifier.Domain.Entities.DocumentExternalLinks.ValueObjects.Classifications;

public sealed class ClassifierDocumentClassification
{
    public ClassifierDocumentClassification(string? category, string? type, string? kind)
    {
        Category = category;
        Type = type;
        Kind = kind;
    }

    public string? Category { get; }
    public string? Type { get; }
    public string? Kind { get; }

    public override string ToString()
    {
        return $"category: {Category}, type: {Type}, kind: {Kind}, ";
    }
}
