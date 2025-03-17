using Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.SigningData.Worflows.Statuses;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.SigningData.Workflows;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.SigningData.Workflows.Status;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.SigningData.Worflows;

internal static class DocumentSigningWorkflowDtoConverter
{
    public static DocumentSigningWorkflowExternal ToExternal(DocumentSigningWorkflowDto signingWorkflow)
    {
        Id<DocumentSigningWorkflowExternal> id = IdConverterFrom<DocumentSigningWorkflowExternal>.FromString(signingWorkflow.Id);

        DocumentSigningWorkflowStatusExternal status = DocumentSigningWorkflowStatusDtoConverter.ToExternal(signingWorkflow.Status);

        var result = new DocumentSigningWorkflowExternal(id, status);

        return result;
    }
}
