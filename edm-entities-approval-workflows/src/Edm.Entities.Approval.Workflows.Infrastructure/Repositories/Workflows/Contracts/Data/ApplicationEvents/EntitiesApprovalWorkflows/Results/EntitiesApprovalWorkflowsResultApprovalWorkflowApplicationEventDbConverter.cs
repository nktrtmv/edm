using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Results;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Results.WorkflowCompleted;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.ApplicationEvents.EntitiesApprovalWorkflows.Results.WorkflowCompleted;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.ApplicationEvents.EntitiesApprovalWorkflows.Results;

internal static class EntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEventDbConverter
{
    internal static ApprovalWorkflowApplicationEventDb FromDomain(EntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEvent applicationEvent)
    {
        EntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEventDb asEntitiesApprovalWorkflowsResult = applicationEvent switch
        {
            WorkflowCompletedEntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEvent e =>
                WorkflowCompletedEntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEventDbConverter.FromDomain(e),

            _ => throw new ArgumentTypeOutOfRangeException(applicationEvent)
        };

        var result = new ApprovalWorkflowApplicationEventDb
        {
            AsEntitiesApprovalWorkflowsResult = asEntitiesApprovalWorkflowsResult
        };

        return result;
    }

    internal static EntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEvent ToDomain(
        EntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEventDb applicationEvent)
    {
        EntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEvent result = applicationEvent.ResultCase switch
        {
            EntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEventDb.ResultOneofCase.AsWorkflowCompleted =>
                WorkflowCompletedEntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEventDbConverter.ToDomain(applicationEvent.AsWorkflowCompleted),

            _ => throw new ArgumentTypeOutOfRangeException(applicationEvent.ResultCase)
        };

        return result;
    }
}
