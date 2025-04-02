using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Updates.Workflows.Approval.Statuses;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Application.DocumentsWorkflows.Approval.Results.WorkflowCompleted.Contracts.Statuses;

internal static class DocumentApprovalStatusInternalConverter
{
    internal static DocumentApprovalStatus ToDomain(DocumentApprovalStatusInternal status)
    {
        DocumentApprovalStatus result = status switch
        {
            DocumentApprovalStatusInternal.Approved => DocumentApprovalStatus.Approved,
            DocumentApprovalStatusInternal.Cancelled => DocumentApprovalStatus.Cancelled,
            DocumentApprovalStatusInternal.ReturnedToRework => DocumentApprovalStatus.ToRework,
            DocumentApprovalStatusInternal.ApprovedWithRemark => DocumentApprovalStatus.ApprovedWithRemark,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
