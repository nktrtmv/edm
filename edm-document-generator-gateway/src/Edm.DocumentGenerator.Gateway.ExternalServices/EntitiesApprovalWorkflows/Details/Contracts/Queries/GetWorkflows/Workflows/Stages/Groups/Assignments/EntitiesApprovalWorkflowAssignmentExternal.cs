using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.CompletionDetails;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.Statuses;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.
    Assignments;

public sealed class EntitiesApprovalWorkflowAssignmentExternal
{
    public EntitiesApprovalWorkflowAssignmentExternal(
        string id,
        string executorId,
        EntitiesApprovalWorkflowAssignmentStatusExternal status,
        DateTime createdDate,
        EntitiesApprovalWorkflowAssignmentCompletionDetailsExternal? completionDetails,
        string? authorId,
        bool isFixed)
    {
        Id = id;
        ExecutorId = executorId;
        Status = status;
        CreatedDate = createdDate;
        CompletionDetails = completionDetails;
        AuthorId = authorId;
        IsFixed = isFixed;
    }

    public string Id { get; }
    public string ExecutorId { get; }
    public EntitiesApprovalWorkflowAssignmentStatusExternal Status { get; }
    public DateTime CreatedDate { get; }
    public EntitiesApprovalWorkflowAssignmentCompletionDetailsExternal? CompletionDetails { get; }
    public string? AuthorId { get; }
    public bool IsFixed { get; }

    public bool IsCompleted => CompletionDetails is not null;
}
