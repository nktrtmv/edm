namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Actions.Services.GetDocumentsToSign.Contracts;

internal sealed class GetDocumentsToSignSigningWorkflowActionQuery
{
    internal required string WorkflowId { get; init; }
    internal required string CurrentUserId { get; init; }
    internal required bool IsCurrentUserAdmin { get; init; }
}
