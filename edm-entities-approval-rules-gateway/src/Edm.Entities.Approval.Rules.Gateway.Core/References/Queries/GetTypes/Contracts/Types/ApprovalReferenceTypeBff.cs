using Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.GetTypes.Contracts.Types.SearchKinds;

namespace Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.GetTypes.Contracts.Types;

public sealed class ApprovalReferenceTypeBff
{
    public required string Id { get; init; }
    public string? DisplayName { get; set; }
    public required ApprovalReferenceSearchKindBff SearchKind { get; init; }
    public required string[] ParentIds { get; init; }
}
