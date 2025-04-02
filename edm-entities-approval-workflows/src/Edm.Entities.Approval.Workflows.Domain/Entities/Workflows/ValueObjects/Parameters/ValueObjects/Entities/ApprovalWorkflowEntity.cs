using Edm.Entities.Approval.Workflows.Domain.ValueObjects;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Entities;

public sealed class ApprovalWorkflowEntity(EntityId id, DomainId domainId)
{
    public EntityId Id { get; } = id;
    public DomainId DomainId { get; } = domainId;

    public override string ToString()
    {
        return $"{{ Id: {Id}, DomainId: {DomainId} }}";
    }
}
