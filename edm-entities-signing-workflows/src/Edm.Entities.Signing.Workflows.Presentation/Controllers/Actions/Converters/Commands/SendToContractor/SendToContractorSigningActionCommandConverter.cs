using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.SendToContractor.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Contracts.Contexts;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Commands.SendToContractor;

internal static class SendToContractorSigningActionCommandConverter
{
    internal static SendToContractorSigningActionCommandInternal ToInternal(SendToContractorSigningActionCommand command)
    {
        SigningActionContextInternal context = SigningActionContextDtoConverter.ToInternal(command.Context);

        var result = new SendToContractorSigningActionCommandInternal(context);

        return result;
    }
}
