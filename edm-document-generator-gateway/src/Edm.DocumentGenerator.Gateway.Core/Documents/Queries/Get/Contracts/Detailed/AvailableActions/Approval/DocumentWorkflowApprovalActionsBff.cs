using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions.Approval.Kinds;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Contracts.Contexts;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions.Approval;

public sealed class DocumentWorkflowApprovalActionsBff
{
    public required DocumentWorkflowApprovalActionsContextBff Context { get; init; }
    public required DocumentWorkflowApprovalActionKindBff[] Actions { get; init; }
}
