using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Converters.Queries.GetTypes.Contracts.Types.SearchKinds;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.GetTypes.Contracts.Types;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Converters.Queries.GetTypes.Contracts.Types;

internal static class ApprovalReferenceTypeExternalConverter
{
    internal static ApprovalReferenceTypeExternal FromDto(ApprovalReferenceTypeDto type)
    {
        var searchKind =
            ApprovalReferenceSearchKindExternalConverter.FromDto(type.SearchKind);

        string[] parentIds = type.ParentIds.ToArray();

        var result = new ApprovalReferenceTypeExternal(
            type.Id,
            type.DisplayName,
            searchKind,
            parentIds);

        return result;
    }
}
