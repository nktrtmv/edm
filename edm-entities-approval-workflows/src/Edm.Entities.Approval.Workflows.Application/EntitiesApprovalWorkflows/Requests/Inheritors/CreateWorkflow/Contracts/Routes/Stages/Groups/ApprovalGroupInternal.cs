namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups;

public abstract class ApprovalGroupInternal
{
    protected ApprovalGroupInternal(string name)
    {
        Name = name;
    }

    public string Name { get; }
}
