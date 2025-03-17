using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.SigningData.Workflows;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.SigningData;

public sealed class DocumentSigningDataInternal
{
    internal DocumentSigningDataInternal(DocumentSigningWorkflowInternal[] workflows)
    {
        Workflows = workflows;
    }

    public DocumentSigningWorkflowInternal[] Workflows { get; }
}
