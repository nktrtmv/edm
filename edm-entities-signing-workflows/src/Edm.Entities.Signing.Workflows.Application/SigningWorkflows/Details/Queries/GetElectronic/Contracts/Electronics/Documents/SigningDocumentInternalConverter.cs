using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Documents.States;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Merkers;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Documents;

internal static class SigningDocumentInternalConverter
{
    internal static SigningDocumentInternal FromDomain(SigningDocument document)
    {
        Id<EdoInternal>? edoId = NullableConverter.Convert(document.EdoId, IdConverterFrom<EdoInternal>.From);

        Id<AttachmentInternal> documentId = IdConverterFrom<AttachmentInternal>.From(document.DocumentId);

        Id<AttachmentInternal>? signatureId = NullableConverter.Convert(document.SignatureId, IdConverterFrom<AttachmentInternal>.From);

        SigningDocumentStateInternal state = SigningDocumentStateInternalConverter.FromDomain(document.State);

        var result = new SigningDocumentInternal(edoId, documentId, signatureId, state);

        return result;
    }
}
