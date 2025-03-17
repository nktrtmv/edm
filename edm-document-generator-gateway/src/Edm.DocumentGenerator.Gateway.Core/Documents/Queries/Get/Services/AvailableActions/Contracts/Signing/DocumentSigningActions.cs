using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetAvailableActions.Actions.Kinds;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions.Contracts.Signing;

internal sealed class DocumentSigningActions
{
    internal DocumentSigningActions(string workflowId, SigningWorkflowActionKindExternal[] actions)
    {
        WorkflowId = workflowId;
        Actions = actions;
    }

    internal string WorkflowId { get; }
    internal SigningWorkflowActionKindExternal[] Actions { get; }
}
