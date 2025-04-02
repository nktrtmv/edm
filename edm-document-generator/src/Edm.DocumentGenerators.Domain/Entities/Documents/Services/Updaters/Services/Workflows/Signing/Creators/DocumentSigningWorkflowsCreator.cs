using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.ValueObjects.StatusChanges;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Services.Workflows.Signing.Creators;

internal static class DocumentSigningWorkflowsCreator
{
    internal static void TryCreate(IRoleAdapter roleAdapter, Document document, Id<User> currentUserId, DocumentStatusChange? statusChange)
    {
        if (ShallBeSkipped(statusChange))
        {
            return;
        }

        ValidateLastWorkFlowIsFinished(document);

        DocumentSigningWorkflow workflow = DocumentSigningWorkflowFactory.CreateNew();

        document.SigningData.Workflows = document.SigningData.Workflows.Append(workflow).ToArray();

        CreateWorkflowEntitiesSigningWorkflowsRequestDocumentApplicationEvent createWorkflow =
            CreateWorkflowEntitiesSigningWorkflowsRequestDocumentApplicationEventFactory.Create(roleAdapter, document, currentUserId);

        document.ApplicationEvents.Add(createWorkflow);
    }

    private static bool ShallBeSkipped(DocumentStatusChange? statusChange)
    {
        bool result = statusChange?.Transition.To.Type != DocumentStatusType.Signing;

        return result;
    }

    private static void ValidateLastWorkFlowIsFinished(Document document)
    {
        DocumentSigningWorkflow? lastWorkflow = document.SigningData.Workflows.LastOrDefault();

        if (lastWorkflow is null || lastWorkflow.Status == DocumentSigningWorkflowStatus.Finished)
        {
            return;
        }

        if (lastWorkflow is { Status: DocumentSigningWorkflowStatus.InProgress })
        {
            throw new BusinessLogicApplicationException(
                $"""
                 Document has unfinished last Signing workflow.
                 DocumentId: {document.Id}
                 WorkflowId: {lastWorkflow.Id}
                 """);
        }

        throw new BusinessLogicApplicationException(
            $"""
             Document has Signing workflow in unexpected status '{lastWorkflow.Status}'.
             DocumentId: {document.Id}
             WorkflowId: {lastWorkflow.Id}
             """);
    }
}
