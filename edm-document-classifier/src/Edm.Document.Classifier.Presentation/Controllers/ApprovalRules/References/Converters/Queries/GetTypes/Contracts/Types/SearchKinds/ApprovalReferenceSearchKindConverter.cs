using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts.Types.SearchKinds;
using Edm.Document.Classifier.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.Document.Classifier.Presentation.Controllers.ApprovalRules.References.Converters.Queries.GetTypes.Contracts.Types.SearchKinds;

internal static class ApprovalReferenceSearchKindConverter
{
    internal static ApprovalReferenceSearchKindDto ToDto(DocumentReferenceSearchKindInternal searchKind)
    {
        ApprovalReferenceSearchKindDto result = searchKind switch
        {
            DocumentReferenceSearchKindInternal.FixedList => ApprovalReferenceSearchKindDto.FixedList,
            DocumentReferenceSearchKindInternal.Search => ApprovalReferenceSearchKindDto.Search,
            _ => throw new ArgumentTypeOutOfRangeException(searchKind)
        };

        return result;
    }
}
