using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.ApprovalData.Workflows.Statuses;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.ApprovalData.Workflows.Statuses;

internal static class DocumentApprovalWorkflowStatusDtoConverter
{
    internal static DocumentApprovalWorkflowStatusDto FromInternal(DocumentApprovalWorkflowStatusInternal status)
    {
        DocumentApprovalWorkflowStatusDto result = status switch
        {
            DocumentApprovalWorkflowStatusInternal.InProgress => DocumentApprovalWorkflowStatusDto.InProgress,
            DocumentApprovalWorkflowStatusInternal.Finished => DocumentApprovalWorkflowStatusDto.Finished,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
