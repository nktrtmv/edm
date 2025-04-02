using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Events;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Results;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.ApplicationEvents.EntitiesApprovalWorkflows.Events;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.ApplicationEvents.EntitiesApprovalWorkflows.Results;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.ApplicationEvents;

internal static class ApprovalWorkflowApplicationEventDbConverter
{
    internal static ApprovalWorkflowApplicationEventDb FromDomain(ApprovalWorkflowApplicationEvent applicationEvent)
    {
        var result = applicationEvent switch
        {
            EntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEvent e =>
                EntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEventDbConverter.FromDomain(e),

            EntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEvent e =>
                EntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventDbConverter.FromDomain(e),

            _ => throw new ArgumentTypeOutOfRangeException(applicationEvent)
        };

        return result;
    }

    internal static ApprovalWorkflowApplicationEvent ToDomain(ApprovalWorkflowApplicationEventDb applicationEvent)
    {
        ApprovalWorkflowApplicationEvent result = applicationEvent.ValueCase switch
        {
            ApprovalWorkflowApplicationEventDb.ValueOneofCase.AsEntitiesApprovalWorkflowsResult =>
                EntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEventDbConverter.ToDomain(applicationEvent.AsEntitiesApprovalWorkflowsResult),

            ApprovalWorkflowApplicationEventDb.ValueOneofCase.AsEntitiesApprovalWorkflowsEvent =>
                EntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventDbConverter.ToDomain(applicationEvent.AsEntitiesApprovalWorkflowsEvent),

            _ => throw new ArgumentTypeOutOfRangeException(applicationEvent.ValueCase)
        };

        return result;
    }
}
