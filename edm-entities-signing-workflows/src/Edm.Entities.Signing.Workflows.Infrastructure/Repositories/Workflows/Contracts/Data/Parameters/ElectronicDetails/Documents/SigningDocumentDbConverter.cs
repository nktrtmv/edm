using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.ValueObjects.States;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.SigningWorkflows.Contracts;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters.ElectronicDetails.Documents.States;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters.ElectronicDetails.Documents;

internal static class SigningDocumentDbConverter
{
    internal static SigningDocumentDb FromDomain(SigningDocument document)
    {
        string? edoId = NullableConverter.Convert(document.EdoId, IdConverterTo.ToString);

        var documentAttachmentId = IdConverterTo.ToString(document.DocumentId);

        string? signatureAttachmentId = NullableConverter.Convert(document.SignatureId, IdConverterTo.ToString);

        SigningDocumentStateDb state = SigningDocumentStateDbConverter.FromDomain(document.State);

        var result = new SigningDocumentDb
        {
            EdoId = edoId,
            DocumentAttachmentId = documentAttachmentId,
            SignatureAttachmentId = signatureAttachmentId,
            State = state
        };

        return result;
    }

    internal static SigningDocument ToDomain(SigningDocumentDb document)
    {
        Id<Edo>? edoId =
            NullableConverter.Convert(document.EdoId, IdConverterFrom<Edo>.FromString);

        Id<Attachment> documentId =
            IdConverterFrom<Attachment>.FromString(document.DocumentAttachmentId);

        Id<Attachment>? signatureId =
            NullableConverter.Convert(document.SignatureAttachmentId, IdConverterFrom<Attachment>.FromString);

        SigningDocumentState state =
            SigningDocumentStateDbConverter.ToDomain(document.State);

        SigningDocument result =
            SigningDocumentFactory.CreateFromDb(edoId, documentId, signatureId, state);

        return result;
    }
}
