using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.SearchKinds;
using Edm.Document.Classifier.GenericSubdomain.Exceptions;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts.Types.SearchKinds;

internal static class ReferenceSearchKindInternalConverter
{
    internal static DocumentReferenceSearchKindInternal FromDomain(DocumentReferenceSearchKind searchKind)
    {
        DocumentReferenceSearchKindInternal result = searchKind switch
        {
            DocumentReferenceSearchKind.Search => DocumentReferenceSearchKindInternal.Search,
            DocumentReferenceSearchKind.FixedList => DocumentReferenceSearchKindInternal.FixedList,
            _ => throw new ArgumentTypeOutOfRangeException(searchKind)
        };

        return result;
    }
}
