using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.Cancel.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Contracts.Contexts;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Commands.Cancel;

internal static class CancelSigningActionCommandConverter
{
    internal static CancelSigningActionCommandInternal ToInternal(CancelSigningActionCommand command)
    {
        SigningActionContextInternal context = SigningActionContextDtoConverter.ToInternal(command.Context);

        var result = new CancelSigningActionCommandInternal(context, command.Comment);

        return result;
    }
}
