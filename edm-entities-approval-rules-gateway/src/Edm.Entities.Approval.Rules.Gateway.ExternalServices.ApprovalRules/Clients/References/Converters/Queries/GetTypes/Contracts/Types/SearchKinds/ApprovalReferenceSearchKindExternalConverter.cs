using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.GetTypes.Contracts.Types.SearchKinds;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Converters.Queries.GetTypes.Contracts.Types.
    SearchKinds;

internal static class ApprovalReferenceSearchKindExternalConverter
{
    internal static ApprovalReferenceSearchKindExternal FromDto(ApprovalReferenceSearchKindDto searchKind)
    {
        var result = searchKind switch
        {
            ApprovalReferenceSearchKindDto.Search
                => ApprovalReferenceSearchKindExternal.Search,

            ApprovalReferenceSearchKindDto.FixedList
                => ApprovalReferenceSearchKindExternal.FixedList,

            _ => throw new ArgumentTypeOutOfRangeException(searchKind)
        };

        return result;
    }
}
