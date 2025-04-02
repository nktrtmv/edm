using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions;

public abstract class DocumentWorkflowSigningActionService
{
    protected DocumentWorkflowSigningActionService(ISigningWorkflowsActionsClient actions)
    {
        Actions = actions;
    }

    protected ISigningWorkflowsActionsClient Actions { get; }
}
