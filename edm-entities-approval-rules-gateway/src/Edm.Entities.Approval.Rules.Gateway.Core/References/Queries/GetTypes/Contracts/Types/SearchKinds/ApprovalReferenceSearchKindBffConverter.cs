using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.GetTypes.Contracts.Types.SearchKinds;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.GetTypes.Contracts.Types.SearchKinds;

internal static class ApprovalReferenceSearchKindBffConverter
{
    internal static ApprovalReferenceSearchKindBff FromExternal(ApprovalReferenceSearchKindExternal searchKind)
    {
        var result = searchKind switch
        {
            ApprovalReferenceSearchKindExternal.Search => ApprovalReferenceSearchKindBff.Search,
            ApprovalReferenceSearchKindExternal.FixedList => ApprovalReferenceSearchKindBff.FixedList,
            _ => throw new ArgumentTypeOutOfRangeException(searchKind)
        };

        return result;
    }
}
