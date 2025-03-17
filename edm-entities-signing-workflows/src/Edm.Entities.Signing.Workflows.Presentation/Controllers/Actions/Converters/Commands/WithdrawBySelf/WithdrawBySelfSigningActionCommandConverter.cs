using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.WithdrawBySelf.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Contracts.Contexts;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Commands.WithdrawBySelf;

internal static class WithdrawBySelfSigningActionCommandConverter
{
    internal static WithdrawBySelfSigningActionCommandInternal ToInternal(WithdrawBySelfSigningActionCommand command)
    {
        SigningActionContextInternal context = SigningActionContextDtoConverter.ToInternal(command.Context);

        var result = new WithdrawBySelfSigningActionCommandInternal(context, command.Comment);

        return result;
    }
}
