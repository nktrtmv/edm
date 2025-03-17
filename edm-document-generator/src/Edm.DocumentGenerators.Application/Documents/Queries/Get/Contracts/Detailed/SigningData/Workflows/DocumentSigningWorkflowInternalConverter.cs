using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.SigningData.Workflows.Statuses;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.SigningData.Workflows;

internal static class DocumentSigningWorkflowInternalConverter
{
    internal static DocumentSigningWorkflowInternal FromDomain(DocumentSigningWorkflow workflow)
    {
        Id<DocumentSigningWorkflowInternal> id = IdConverterFrom<DocumentSigningWorkflowInternal>.From(workflow.Id);

        DocumentSigningWorkflowStatusInternal status = DocumentSigningWorkflowStatusInternalConverter.FromDomain(workflow.Status);

        var result = new DocumentSigningWorkflowInternal(id, status);

        return result;
    }
}
