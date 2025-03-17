using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.WithdrawByContractor.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Contracts.Contexts;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Commands.WithdrawByContractor;

internal static class WithdrawByContractorSigningActionCommandConverter
{
    internal static WithdrawByContractorSigningActionCommandInternal ToInternal(WithdrawByContractorSigningActionCommand command)
    {
        SigningActionContextInternal context = SigningActionContextDtoConverter.ToInternal(command.Context);

        var result = new WithdrawByContractorSigningActionCommandInternal(context, command.Comment);

        return result;
    }
}
