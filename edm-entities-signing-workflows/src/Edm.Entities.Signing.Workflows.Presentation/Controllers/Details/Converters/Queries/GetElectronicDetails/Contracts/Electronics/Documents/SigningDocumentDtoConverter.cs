using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Documents;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetElectronicDetails.Contracts.Electronics.Documents.States;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetElectronicDetails.Contracts.Electronics.Documents;

internal static class SigningDocumentDtoConverter
{
    internal static SigningDocumentDto FromInternal(SigningDocumentInternal document)
    {
        string? edoId = NullableConverter.Convert(document.EdoId, IdConverterTo.ToString);

        var documentAttachmentId = IdConverterTo.ToString(document.DocumentId);

        string? signatureAttachmentId = NullableConverter.Convert(document.SignatureId, IdConverterTo.ToString);

        SigningDocumentStateDto state = SigningDocumentStateDtoConverter.FromInternal(document.State);

        var result = new SigningDocumentDto
        {
            EdoId = edoId,
            DocumentAttachmentId = documentAttachmentId,
            SignatureAttachmentId = signatureAttachmentId,
            State = state
        };

        return result;
    }
}
