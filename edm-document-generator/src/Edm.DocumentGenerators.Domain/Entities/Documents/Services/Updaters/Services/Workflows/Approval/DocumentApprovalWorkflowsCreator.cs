using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.ValueObjects.StatusChanges;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Services.Workflows.Approval;

internal static class DocumentApprovalWorkflowsCreator
{
    internal static void TryCreate(Document document, Id<User> currentUserId, DocumentStatusChange? statusChange)
    {
        if (ShallBeSkipped(statusChange))
        {
            return;
        }

        ValidateLastWorkFlowIsFinished(document);

        DocumentApprovalWorkflow workflow = DocumentApprovalWorkflowFactory.CreateNew();

        document.ApprovalData.Workflows = document.ApprovalData.Workflows.Append(workflow).ToArray();

        CreateWorkflowEntitiesApprovalWorkflowsRequestDocumentApplicationEvent createWorkflow =
            CreateWorkflowEntitiesApprovalWorkflowsRequestDocumentApplicationEventFactory.Create(document, currentUserId);

        document.ApplicationEvents.Add(createWorkflow);
    }

    private static bool ShallBeSkipped(DocumentStatusChange? statusChange)
    {
        bool result = statusChange?.Transition.To.Type != DocumentStatusType.Approval;

        return result;
    }

    private static void ValidateLastWorkFlowIsFinished(Document document)
    {
        DocumentApprovalWorkflow? lastWorkflow = document.ApprovalData.Workflows.LastOrDefault();

        if (lastWorkflow is null || lastWorkflow.Status == DocumentApprovalWorkflowStatus.Finished)
        {
            return;
        }

        if (lastWorkflow is { Status: DocumentApprovalWorkflowStatus.InProgress })
        {
            throw new BusinessLogicApplicationException(
                $"""
                 Document has unfinished last Approval workflow.
                 DocumentId: {document.Id}
                 WorkflowId: {lastWorkflow.Id}
                 """);
        }

        throw new BusinessLogicApplicationException(
            $"""
             Document has an Approval workflow in unexpected status '{lastWorkflow.Status}'.
             DocumentId: {document.Id}
             WorkflowId: {lastWorkflow.Id}
             """);
    }
}
