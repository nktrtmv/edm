using Edm.Entities.Signing.Edx.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts;

namespace Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Converters.Commands.SendDocuments.SigningContexts;

internal static class SigningEdxContextConverter
{
    internal static SigningEdxContextDto FromExternal(SendSigningEdxDocumentsCommandExternal request)
    {
        var result = new SigningEdxContextDto
        {
            SignerId = request.SignerId?.ToString(),
        };

        return result;
    }
}
