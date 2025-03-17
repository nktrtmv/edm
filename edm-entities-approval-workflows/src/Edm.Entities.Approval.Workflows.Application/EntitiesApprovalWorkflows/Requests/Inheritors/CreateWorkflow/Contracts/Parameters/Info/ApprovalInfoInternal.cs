namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Info;

public readonly struct ApprovalInfoInternal
{
    public string Title { get; }
    public string Description { get; }

    public ApprovalInfoInternal(
        string title,
        string description)
    {
        Title = title;
        Description = description;
    }
}
