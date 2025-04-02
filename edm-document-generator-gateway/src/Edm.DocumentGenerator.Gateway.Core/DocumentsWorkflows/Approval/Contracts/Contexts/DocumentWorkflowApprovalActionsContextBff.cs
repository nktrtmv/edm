namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Contracts.Contexts;

public sealed class DocumentWorkflowApprovalActionsContextBff
{
    public required string WorkflowId { get; init; }
    public required string StageId { get; init; }
}
