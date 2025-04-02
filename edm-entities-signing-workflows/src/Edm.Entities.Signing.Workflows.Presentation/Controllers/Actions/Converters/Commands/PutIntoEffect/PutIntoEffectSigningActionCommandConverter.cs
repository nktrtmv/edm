using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.PutIntoEffect.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Contracts.Contexts;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Commands.PutIntoEffect;

internal static class PutIntoEffectSigningActionCommandConverter
{
    internal static PutIntoEffectSigningActionCommandInternal ToInternal(PutIntoEffectSigningActionCommand command)
    {
        SigningActionContextInternal context = SigningActionContextDtoConverter.ToInternal(command.Context);

        var result = new PutIntoEffectSigningActionCommandInternal(context);

        return result;
    }
}
