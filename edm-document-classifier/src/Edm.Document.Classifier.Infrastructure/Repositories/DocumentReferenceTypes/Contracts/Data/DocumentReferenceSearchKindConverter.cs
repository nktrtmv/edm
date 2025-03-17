using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.SearchKinds;

namespace Edm.Document.Classifier.Infrastructure.Repositories.DocumentReferenceTypes.Contracts.Data;

internal static class DocumentReferenceSearchKindConverter
{
    public static DocumentReferenceSearchKind ToDomain(DocumentReferenceSearchKindDb searchKind)
    {
        DocumentReferenceSearchKind result = searchKind switch
        {
            DocumentReferenceSearchKindDb.FixedList => DocumentReferenceSearchKind.FixedList,
            DocumentReferenceSearchKindDb.Search => DocumentReferenceSearchKind.Search,
            _ => DocumentReferenceSearchKind.Search
        };

        return result;
    }
    public static DocumentReferenceSearchKindDb FromDomain(DocumentReferenceSearchKind searchKind)
    {
        DocumentReferenceSearchKindDb result = searchKind switch
        {
            DocumentReferenceSearchKind.FixedList => DocumentReferenceSearchKindDb.FixedList,
            DocumentReferenceSearchKind.Search => DocumentReferenceSearchKindDb.Search,
            _ => DocumentReferenceSearchKindDb.Search
        };

        return result;
    }
}
