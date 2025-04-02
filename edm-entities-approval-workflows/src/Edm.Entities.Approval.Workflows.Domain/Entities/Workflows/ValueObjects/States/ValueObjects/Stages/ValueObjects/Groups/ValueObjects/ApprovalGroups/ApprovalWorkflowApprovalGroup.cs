namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups;

public abstract class ApprovalWorkflowApprovalGroup
{
    protected string BaseToString()
    {
        return $"Type: {GetType().Name}";
    }
}
