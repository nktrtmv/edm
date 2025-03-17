using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Entities;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters.Entities;

internal static class ApprovalWorkflowEntityDbConverter
{
    internal static WorkflowEntityDb FromDomain(ApprovalWorkflowEntity entity)
    {
        var result = new WorkflowEntityDb
        {
            Id = entity.Id,
            DomainId = entity.DomainId
        };

        return result;
    }

    internal static ApprovalWorkflowEntity ToDomain(WorkflowEntityDb entity)
    {
        var entityId = EntityId.Parse(entity.Id);
        var domainId = DomainId.Parse(entity.DomainId);

        var result = new ApprovalWorkflowEntity(entityId, domainId);

        return result;
    }
}
