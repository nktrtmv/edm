using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.ReturnToRework.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Contracts.Contexts;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Commands.ReturnToRework;

internal static class ReturnToReworkSigningActionCommandConverter
{
    internal static ReturnToReworkSigningActionCommandInternal ToInternal(ReturnToReworkSigningActionCommand command)
    {
        SigningActionContextInternal context = SigningActionContextDtoConverter.ToInternal(command.Context);

        var result = new ReturnToReworkSigningActionCommandInternal(context, command.Comment);

        return result;
    }
}
