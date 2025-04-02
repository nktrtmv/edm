using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.SearchValues.Contracts.Keys.ParentValues;

namespace Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.SearchValues.Contracts.Keys;

public sealed class ApprovalReferenceKeyBff
{
    public required EntityTypeKeyBff EntityTypeKey { init; get; }
    public required string ReferenceTypeId { get; init; }
    public ApprovalReferenceParentValuesBff[] ParentValues { get; init; } = Array.Empty<ApprovalReferenceParentValuesBff>();
}
