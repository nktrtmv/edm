using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Documents.States;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Merkers;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Documents;

public sealed class SigningDocumentInternal
{
    internal SigningDocumentInternal(
        Id<EdoInternal>? edoId,
        Id<AttachmentInternal> documentId,
        Id<AttachmentInternal>? signatureId,
        SigningDocumentStateInternal state)
    {
        EdoId = edoId;
        DocumentId = documentId;
        SignatureId = signatureId;
        State = state;
    }

    public Id<EdoInternal>? EdoId { get; }
    public Id<AttachmentInternal> DocumentId { get; }
    public Id<AttachmentInternal>? SignatureId { get; }
    public SigningDocumentStateInternal State { get; }
}
