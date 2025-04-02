using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Commands.Contexts;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Actions.Converters.Commands.Contexts;

internal static class SigningWorkflowActionContextExternalConverter
{
    internal static SigningActionContextDto ToDto(SigningWorkflowActionContextExternal context)
    {
        var result = new SigningActionContextDto
        {
            WorkflowId = context.WorkflowId,
            CurrentUserId = context.CurrentUserId,
            IsCurrentUserAdmin = context.IsCurrentUserAdmin
        };

        return result;
    }
}
