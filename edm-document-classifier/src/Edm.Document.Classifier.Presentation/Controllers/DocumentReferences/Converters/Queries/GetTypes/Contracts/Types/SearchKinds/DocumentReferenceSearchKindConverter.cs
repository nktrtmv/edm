using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts.Types.SearchKinds;
using Edm.Document.Classifier.GenericSubdomain.Exceptions;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Queries.GetTypes.Contracts.Types.SearchKinds;

internal static class DocumentReferenceSearchKindConverter
{
    internal static DocumentReferenceSearchKindDto ToDto(DocumentReferenceSearchKindInternal searchKind)
    {
        DocumentReferenceSearchKindDto result = searchKind switch
        {
            DocumentReferenceSearchKindInternal.FixedList => DocumentReferenceSearchKindDto.FixedList,
            DocumentReferenceSearchKindInternal.Search => DocumentReferenceSearchKindDto.Search,
            _ => throw new ArgumentTypeOutOfRangeException(searchKind)
        };

        return result;
    }
}
