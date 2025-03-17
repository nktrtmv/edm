using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;

internal static class SigningActionContextInternalConverter
{
    internal static SigningActionContext ToDomain(SigningActionContextInternal context, SigningWorkflow workflow)
    {
        Id<User> currentUserId = IdConverterFrom<User>.From(context.CurrentUserId);

        var result = new SigningActionContext(workflow, currentUserId, context.IsCurrentUserAdmin);

        return result;
    }
}
