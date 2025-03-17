using Edm.Entities.Signing.Edx.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Converters.Commands.SendDocuments.Documents;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Converters.Commands.SendDocuments.Entites;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Converters.Commands.SendDocuments.Parties;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Converters.Commands.SendDocuments.SigningContexts;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Converters.Commands.SendDocuments;

internal static class SendSigningEdxDocumentsCommandConverter
{
    internal static SigningEdxRequestKey ToKey(SendSigningEdxDocumentsCommandExternal request)
    {
        var entityId = IdConverterTo.ToString(request.Entity.Id);

        var result = new SigningEdxRequestKey
        {
            Key = entityId
        };

        return result;
    }

    internal static SigningEdxRequestValue ToValue(SendSigningEdxDocumentsCommandExternal request)
    {
        var signinId = IdConverterTo.ToString(request.SigningId);

        SendDocumentsSigningEdxCommandDto asSendDocuments = ToSendDocuments(request);

        var result = new SigningEdxRequestValue
        {
            RequestId = signinId,
            AsSendDocuments = asSendDocuments,
        };

        return result;
    }

    private static SendDocumentsSigningEdxCommandDto ToSendDocuments(SendSigningEdxDocumentsCommandExternal request)
    {
        var signinId = IdConverterTo.ToString(request.SigningId);

        SigningEdxContextDto signingContext = SigningEdxContextConverter.FromExternal(request);

        SigningEdxEntityDto entity = SigningEdxEntityDtoConverter.FromExternal(request.Entity, request.Summary);

        SigningEdxPartiesDto parties = SigningEdxPartiesDtoConverter.FromExternal(request.Parties);

        SigningEdxDocumentToSendDto[] documents = request.Documents.Select(SigningEdxDocumentDtoConverter.FromExternal).ToArray();

        var result = new SendDocumentsSigningEdxCommandDto
        {
            SigningId = signinId,
            SigningContext = signingContext,
            Entity = entity,
            Parties = parties,
            Documents = { documents },
        };

        return result;
    }
}
