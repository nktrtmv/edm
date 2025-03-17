using Edm.DocumentGenerators.Application.Contracts.DocumentsStagesTypes;
using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.DocumentsDetails.Queries.GetDocumentsReferenceDetails.Contracts.Contracts.DocumentReferenceDetails;

public sealed class DocumentReferenceDetailsInternal
{
    public DocumentReferenceDetailsInternal(Id<DocumentInternal> documentId, string registrationNumber, DocumentStageTypeInternal stageType)
    {
        DocumentId = documentId;
        RegistrationNumber = registrationNumber;
        StageType = stageType;
    }

    public Id<DocumentInternal> DocumentId { get; }
    public string RegistrationNumber { get; }
    public DocumentStageTypeInternal StageType { get; }
}
