using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.GetTypes.Contracts.Types.SearchKinds;

namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.GetTypes.Contracts.Types;

public sealed class ApprovalReferenceTypeExternal
{
    public ApprovalReferenceTypeExternal(
        string id,
        string displayName,
        ApprovalReferenceSearchKindExternal searchKind,
        string[] parentIds)
    {
        Id = id;
        DisplayName = displayName;
        SearchKind = searchKind;
        ParentIds = parentIds;
    }

    public string Id { get; }
    public string DisplayName { get; }
    public ApprovalReferenceSearchKindExternal SearchKind { get; }
    public string[] ParentIds { get; }
}
