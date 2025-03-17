using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Updates.Workflows.Approval.Statuses;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Services.Workflows.Approval;

internal static class DocumentApprovalWorkflowsUpdater
{
    internal static DocumentUpdateParameters Update(Document document, DocumentApprovalStatus status)
    {
        DocumentApprovalWorkflow currentWorkflow = document.ApprovalData.Workflows.Last();

        DocumentApprovalWorkflowStatus nextApprovalWorkflowStatus = GetNextApprovalWorkflowStatus(status);

        currentWorkflow.SetStatus(nextApprovalWorkflowStatus);

        DocumentStatusTransitionType nextDocumentStatusTransitionType = GetNextStatusTransitionType(status);

        DocumentStatusTransition nextStatusTransition = document.StatusStateMachine.GetRequiredTransition(document.Status.Id, nextDocumentStatusTransitionType);

        DocumentUpdateParameters result = DocumentUpdateParametersFactory.Create(nextStatusTransition);

        return result;
    }

    private static DocumentApprovalWorkflowStatus GetNextApprovalWorkflowStatus(DocumentApprovalStatus status)
    {
        DocumentApprovalWorkflowStatus result = status switch
        {
            DocumentApprovalStatus.Approved => DocumentApprovalWorkflowStatus.Finished,
            DocumentApprovalStatus.Cancelled => DocumentApprovalWorkflowStatus.Finished,
            DocumentApprovalStatus.ToRework => DocumentApprovalWorkflowStatus.Finished,
            DocumentApprovalStatus.ApprovedWithRemark => DocumentApprovalWorkflowStatus.Finished,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    private static DocumentStatusTransitionType GetNextStatusTransitionType(DocumentApprovalStatus status)
    {
        DocumentStatusTransitionType result = status switch
        {
            DocumentApprovalStatus.Approved => DocumentStatusTransitionType.ApprovalToApproved,
            DocumentApprovalStatus.Cancelled => DocumentStatusTransitionType.ApprovalToCancelled,
            DocumentApprovalStatus.ToRework => DocumentStatusTransitionType.ApprovalToRework,
            DocumentApprovalStatus.ApprovedWithRemark => DocumentStatusTransitionType.ApprovalToApprovedWithRemark,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
