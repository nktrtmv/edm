namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Services.GetAvailableActions.Contracts;

internal sealed class GetSigningWorkflowAvailableActionsQuery
{
    public required string WorkflowId { get; init; }
    public required string CurrentUserId { get; init; }
    public required bool IsCurrentUserAdmin { get; init; }
}
