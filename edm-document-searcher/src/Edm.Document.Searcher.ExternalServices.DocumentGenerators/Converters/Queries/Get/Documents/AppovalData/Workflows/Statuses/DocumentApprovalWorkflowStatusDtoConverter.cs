using Edm.Document.Searcher.ExternalServices.Documents.Contracts.ApprovalData.Workflows.Statuses;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.AppovalData.Workflows.Statuses;

internal static class DocumentApprovalWorkflowStatusDtoConverter
{
    internal static DocumentApprovalWorkflowStatusExternal ToExternal(DocumentApprovalWorkflowStatusDto status)
    {
        DocumentApprovalWorkflowStatusExternal result = status switch
        {
            DocumentApprovalWorkflowStatusDto.InProgress => DocumentApprovalWorkflowStatusExternal.InProgress,
            DocumentApprovalWorkflowStatusDto.Finished => DocumentApprovalWorkflowStatusExternal.Finished,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
