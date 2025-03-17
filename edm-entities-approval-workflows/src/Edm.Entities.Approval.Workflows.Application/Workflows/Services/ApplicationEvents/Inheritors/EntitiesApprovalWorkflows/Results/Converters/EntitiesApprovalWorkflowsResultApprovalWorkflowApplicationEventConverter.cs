using Edm.Entities.Approval.Workflows.Application.Workflows.Services.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Results.Converters.WorkflowCompleted;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Results;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Results.WorkflowCompleted;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Services.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Results.Converters;

internal static class EntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEventConverter
{
    internal static EntitiesApprovalWorkflowsResultInternal FromDomain(
        EntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEvent applicationEvent,
        ApprovalWorkflow workflow)
    {
        EntitiesApprovalWorkflowsResultInternal result = applicationEvent switch
        {
            WorkflowCompletedEntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEvent e =>
                WorkflowCompletedEntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEventConverter.FromDomain(e, workflow),

            _ => throw new ArgumentTypeOutOfRangeException(applicationEvent)
        };

        return result;
    }
}
