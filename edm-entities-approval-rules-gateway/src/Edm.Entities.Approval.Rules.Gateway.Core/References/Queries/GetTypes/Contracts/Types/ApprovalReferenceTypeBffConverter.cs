using Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.GetTypes.Contracts.Types.SearchKinds;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.GetTypes.Contracts.Types;

namespace Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.GetTypes.Contracts.Types;

internal static class ApprovalReferenceTypeBffConverter
{
    internal static ApprovalReferenceTypeBff FromExternal(ApprovalReferenceTypeExternal type)
    {
        var searchKind =
            ApprovalReferenceSearchKindBffConverter.FromExternal(type.SearchKind);

        string[] parentIds = type.ParentIds.ToArray();

        var result = new ApprovalReferenceTypeBff
        {
            Id = type.Id,
            DisplayName = type.DisplayName,
            SearchKind = searchKind,
            ParentIds = parentIds
        };

        return result;
    }
}
