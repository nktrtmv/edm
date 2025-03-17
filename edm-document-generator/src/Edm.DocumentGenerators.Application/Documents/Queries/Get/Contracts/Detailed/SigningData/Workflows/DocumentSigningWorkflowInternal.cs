using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.SigningData.Workflows.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.SigningData.Workflows;

public sealed class DocumentSigningWorkflowInternal
{
    internal DocumentSigningWorkflowInternal(Id<DocumentSigningWorkflowInternal> id, DocumentSigningWorkflowStatusInternal status)
    {
        Id = id;
        Status = status;
    }

    public Id<DocumentSigningWorkflowInternal> Id { get; }
    public DocumentSigningWorkflowStatusInternal Status { get; }
}
