using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApprovalData.Workflows.Statuses;

internal static class DocumentApprovalWorkflowStatusDbConverter
{
    internal static DocumentApprovalWorkflowStatusDb FromDomain(DocumentApprovalWorkflowStatus status)
    {
        DocumentApprovalWorkflowStatusDb result = status switch
        {
            DocumentApprovalWorkflowStatus.InProgress => DocumentApprovalWorkflowStatusDb.InProgress,
            DocumentApprovalWorkflowStatus.Finished => DocumentApprovalWorkflowStatusDb.Finished,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static DocumentApprovalWorkflowStatus ToDomain(DocumentApprovalWorkflowStatusDb status)
    {
        DocumentApprovalWorkflowStatus result = status switch
        {
            DocumentApprovalWorkflowStatusDb.InProgress => DocumentApprovalWorkflowStatus.InProgress,
            DocumentApprovalWorkflowStatusDb.Finished => DocumentApprovalWorkflowStatus.Finished,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
