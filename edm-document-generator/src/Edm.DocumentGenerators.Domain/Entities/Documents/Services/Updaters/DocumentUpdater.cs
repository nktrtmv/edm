using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Services.Setters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Services.Validators;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Services.Workflows.Approval;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Services.Workflows.Signing;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Services.Workflows.Signing.Creators;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Updates.Documents.Generator;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Updates.Workflows.Approval;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Updates.Workflows.Signing;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters;

public static class DocumentUpdater
{
    public static void Update(
        IRoleAdapter roleAdapter,
        Document document,
        DocumentGeneratorDocumentUpdate update)
    {
        Update(roleAdapter, document, update.CurrentUserId, update.Parameters);
    }

    public static void Update(
        IRoleAdapter roleAdapter,
        Document document,
        ApprovalWorkflowDocumentUpdate update)
    {
        if (DocumentApprovalWorkflowsChecker.IsAlreadyProcessed(document, update.WorkflowId))
        {
            return;
        }

        DocumentUpdateParameters? parameters = DocumentApprovalWorkflowsUpdater.Update(document, update.Status);

        Update(roleAdapter, document, update.CurrentUserId, parameters);
    }

    public static void Update(
        IRoleAdapter roleAdapter,
        Document document,
        SigningWorkflowDocumentUpdate update)
    {
        if (DocumentSigningWorkflowsChecker.IsAlreadyProcessed(document, update.WorkflowId))
        {
            return;
        }

        DocumentUpdateParameters? parameters = DocumentSigningWorkflowsUpdater.Update(document, update.Status);

        Update(roleAdapter, document, update.CurrentUserId, parameters);
    }

    public static void Update(
        IRoleAdapter roleAdapter,
        Document document,
        Id<User> currentUserId,
        DocumentUpdateParameters parameters,
        bool skipValidation = false)
    {
        if (!skipValidation)
        {
            DocumentUpdateParametersValidator.Validate(parameters, document);
        }

        DocumentUpdateParametersSetter.Set(parameters, document);

        DocumentApprovalWorkflowsCreator.TryCreate(document, currentUserId, parameters.StatusChange);

        DocumentSigningWorkflowsCreator.TryCreate(
            roleAdapter,
            document,
            currentUserId,
            parameters.StatusChange);

        DocumentEventsTrigger.Trigger(parameters, document, currentUserId, roleAdapter);
    }
}
