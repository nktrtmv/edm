using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Entities;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Entities;

internal static class ApprovalWorkflowEntityInternalConverter
{
    internal static ApprovalWorkflowEntity ToDomain(ApprovalEntityInternal entity)
    {
        var entityId = EntityId.Parse(entity.Id);
        var domainId = DomainId.Parse(entity.DomainId);
        var result = new ApprovalWorkflowEntity(entityId, domainId);

        return result;
    }
}
