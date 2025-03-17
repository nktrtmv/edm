namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Info;

public sealed class ApprovalWorkflowInfo
{
    public ApprovalWorkflowInfo(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public string Title { get; }
    public string Description { get; }

    public override string ToString()
    {
        return $"{{ Title: {Title}, Description: {Description} }}";
    }
}
