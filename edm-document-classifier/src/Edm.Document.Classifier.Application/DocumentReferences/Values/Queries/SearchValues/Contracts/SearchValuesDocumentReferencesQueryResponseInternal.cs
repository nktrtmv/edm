using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.Values;

namespace Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts;

public sealed class SearchValuesDocumentReferencesQueryResponseInternal
{
    internal SearchValuesDocumentReferencesQueryResponseInternal(DocumentReferenceValueInternal[] values)
    {
        Values = values;
    }

    public DocumentReferenceValueInternal[] Values { get; }
}
