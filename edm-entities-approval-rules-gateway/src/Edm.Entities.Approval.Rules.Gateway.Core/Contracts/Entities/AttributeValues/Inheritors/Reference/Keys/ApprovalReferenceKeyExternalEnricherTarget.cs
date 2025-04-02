using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Keys;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers.Targets.Generics.SingleValue;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.Reference.Keys;

public sealed class ApprovalReferenceKeyExternalEnricherTarget : SingleValueEnricherTargetGeneric<int, EntityTypeAttributeDto>
{
    internal ApprovalReferenceKeyExternalEnricherTarget(int id, ApprovalReferenceKeyExternal target)
    {
        Id = id;
        Target = target;
    }

    private int Id { get; }
    private ApprovalReferenceKeyExternal Target { get; }

    protected override int GetKey()
    {
        return Id;
    }

    protected override void EnrichTarget(EntityTypeAttributeDto value)
    {
        Target.ReferenceTypeId = value.AsReference.ReferenceTypeId;
    }
}
