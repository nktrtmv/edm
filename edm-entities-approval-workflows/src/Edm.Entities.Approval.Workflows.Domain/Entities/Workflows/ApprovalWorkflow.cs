using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;

public sealed class ApprovalWorkflow
{
    public ApprovalWorkflow(
        Id<ApprovalWorkflow> id,
        ApprovalWorkflowParameters parameters,
        ApprovalWorkflowState state,
        List<ApprovalWorkflowApplicationEvent> applicationEvents,
        Audit<ApprovalWorkflow> audit)
    {
        Id = id;
        Parameters = parameters;
        State = state;
        ApplicationEvents = applicationEvents;
        Audit = audit;
    }

    public Id<ApprovalWorkflow> Id { get; }
    public ApprovalWorkflowParameters Parameters { get; private set; }
    public ApprovalWorkflowState State { get; private set; }
    public List<ApprovalWorkflowApplicationEvent> ApplicationEvents { get; }
    public Audit<ApprovalWorkflow> Audit { get; }

    public ApprovalWorkflowStatus Status => State.Status;
    public bool IsCompleted => State.IsCompleted;

    public void SetParameters(ApprovalWorkflowParameters parameters)
    {
        Parameters = parameters;
    }

    public override string ToString()
    {
        return $"{{ Id: {Id}, DomainId: {Parameters.Entity.DomainId}, EntityId: {Parameters.Entity.Id}, Status: {Status} }}";
    }
}
