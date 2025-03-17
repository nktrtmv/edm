using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Contracts.Contexts;

internal static class SigningActionContextDtoConverter
{
    internal static SigningActionContextInternal ToInternal(SigningActionContextDto context)
    {
        Id<SigningInternal> workflowId = IdConverterFrom<SigningInternal>.FromString(context.WorkflowId);

        Id<UserInternal> currentUserId = IdConverterFrom<UserInternal>.FromString(context.CurrentUserId);

        var result = new SigningActionContextInternal(workflowId, currentUserId, context.IsCurrentUserAdmin);

        return result;
    }
}
