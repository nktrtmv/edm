using Edm.Document.Searcher.ExternalServices.Documents.Contracts.SigningData.Workflows.Status;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.SigningData.Worflows.Statuses;

internal static class DocumentSigningWorkflowStatusDtoConverter
{
    internal static DocumentSigningWorkflowStatusExternal ToExternal(DocumentSigningWorkflowStatusDto status)
    {
        DocumentSigningWorkflowStatusExternal result = status switch
        {
            DocumentSigningWorkflowStatusDto.InProgress => DocumentSigningWorkflowStatusExternal.InProgress,
            DocumentSigningWorkflowStatusDto.Finished => DocumentSigningWorkflowStatusExternal.Finished,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
