namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions.Signing;

public sealed class DocumentWorkflowSigningActionsBff
{
    public required string WorkflowId { get; init; }
    public required DocumentWorkflowSigningActionBff[] Actions { get; init; }
}
