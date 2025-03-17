using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Keys.ParentsValues;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Contracts.EntityTypesKeys;

namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Keys;

public sealed record ApprovalReferenceKeyExternal
{
    public ApprovalReferenceKeyExternal(
        EntityTypeKeyExternal entityTypeKey,
        string referenceTypeId,
        params ApprovalReferenceParentValuesExternal[] parentValues)
    {
        EntityTypeKey = entityTypeKey;
        ReferenceTypeId = referenceTypeId;
        ParentValues = parentValues;
    }

    public EntityTypeKeyExternal EntityTypeKey { get; init; }
    public string ReferenceTypeId { get; set; }
    public ApprovalReferenceParentValuesExternal[] ParentValues { get; }
}
