using Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.SigningData.Worflows;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.SigningData;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.SigningData.Workflows;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.SigningData;

internal static class DocumentSingingDataDtoConverter
{
    public static DocumentSigningDataExternal ToExternal(DocumentSigningDataDto documentSigningData)
    {
        DocumentSigningWorkflowExternal[] workflows = documentSigningData.Workflows.Select(DocumentSigningWorkflowDtoConverter.ToExternal).ToArray();

        return new DocumentSigningDataExternal(workflows);
    }
}
