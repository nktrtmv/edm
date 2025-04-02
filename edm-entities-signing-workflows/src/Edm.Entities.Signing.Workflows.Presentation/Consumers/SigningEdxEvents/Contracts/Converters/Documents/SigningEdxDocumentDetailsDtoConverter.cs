using Edm.Entities.Signing.Edx.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.ValueObjects.States;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Consumers.SigningEdxEvents.Contracts.Converters.Documents.States;

namespace Edm.Entities.Signing.Workflows.Presentation.Consumers.SigningEdxEvents.Contracts.Converters.Documents;

internal static class SigningEdxDocumentDetailsDtoConverter
{
    internal static SigningDocument ToDomain(SigningEdxDocumentDetailsDto document)
    {
        Id<Attachment> documentId =
            IdConverterFrom<Attachment>.FromString(document.DocumentAttachmentId);

        Id<Edo>? edoId =
            NullableConverter.Convert(document.EdoId, IdConverterFrom<Edo>.FromString);

        SigningDocumentState state =
            SigningEdxDocumentStateDtoConverter.ToDomain(document.State);

        SigningDocument result = SigningDocumentFactory.CreateFrom(documentId, edoId, state);

        return result;
    }
}
