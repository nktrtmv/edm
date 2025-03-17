using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts.Types.SearchKinds;
using Edm.Document.Classifier.GenericSubdomain.Exceptions;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Types.Queries.GetTypes.Contracts.References.SearchConditionTypes;

internal static class GetTypesQueryResponseReferenceSearchConditionTypeConverter
{
    internal static GetTypesQueryResponseReferenceSearchConditionType FromInternal(DocumentReferenceSearchKindInternal searchKind)
    {
        GetTypesQueryResponseReferenceSearchConditionType result = searchKind switch
        {
            DocumentReferenceSearchKindInternal.FixedList => GetTypesQueryResponseReferenceSearchConditionType.FixedList,
            DocumentReferenceSearchKindInternal.Search => GetTypesQueryResponseReferenceSearchConditionType.Search,
            _ => throw new ArgumentTypeOutOfRangeException(searchKind)
        };

        return result;
    }
}
