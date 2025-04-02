using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.ApprovalData.Workflows.Statuses;

internal static class DocumentApprovalWorkflowStatusInternalConverter
{
    internal static DocumentApprovalWorkflowStatusInternal FromDomain(DocumentApprovalWorkflowStatus status)
    {
        DocumentApprovalWorkflowStatusInternal result = status switch
        {
            DocumentApprovalWorkflowStatus.InProgress => DocumentApprovalWorkflowStatusInternal.InProgress,
            DocumentApprovalWorkflowStatus.Finished => DocumentApprovalWorkflowStatusInternal.Finished,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
