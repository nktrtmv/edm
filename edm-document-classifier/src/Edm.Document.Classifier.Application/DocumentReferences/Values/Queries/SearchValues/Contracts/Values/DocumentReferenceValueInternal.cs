using Edm.Document.Classifier.Domain;

namespace Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.Values;

public sealed class DocumentReferenceValueInternal
{
    internal DocumentReferenceValueInternal(string id, string displayValue, string displaySubValue, ITypedReference typedReference)
    {
        Id = id;
        DisplayValue = displayValue;
        DisplaySubValue = displaySubValue;
        TypedReference = typedReference;
    }

    public string Id { get; }
    public string DisplayValue { get; }
    public string DisplaySubValue { get; }
    public ITypedReference TypedReference { get; }
}
