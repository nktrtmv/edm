using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.Sign.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.Sign.Contracts.Contracts.DocumentsWithSignature;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Contracts.Contexts;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Commands.Sign.Converters.DocumentsWithSignature;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Contracts.Contexts;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Commands.Sign;

internal static class SignSigningActionCommandConverter
{
    internal static SignSigningActionCommandInternal ToInternal(SignSigningActionCommand command)
    {
        SigningActionContextInternal context = SigningActionContextDtoConverter.ToInternal(command.Context);

        SigningDocumentWithSignatureInternal[] documents = command.Documents.Select(SigningDocumentWithSignatureDtoConverter.ToInternal).ToArray();

        var result = new SignSigningActionCommandInternal(context, documents);

        return result;
    }
}
