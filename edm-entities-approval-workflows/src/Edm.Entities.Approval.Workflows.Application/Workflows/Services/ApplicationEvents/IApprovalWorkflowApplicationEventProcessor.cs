using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Services.ApplicationEvents;

public interface IApprovalWorkflowApplicationEventProcessor
{
    Task Process(int counter, ApprovalWorkflowApplicationEvent applicationEvent, ApprovalWorkflow workflow, CancellationToken cancellationToken);
}
