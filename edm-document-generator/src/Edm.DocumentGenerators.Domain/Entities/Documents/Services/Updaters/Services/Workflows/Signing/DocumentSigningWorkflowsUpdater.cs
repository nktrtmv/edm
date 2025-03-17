using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Updates.Workflows.Signing.Statuses;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Services.Workflows.Signing;

internal static class DocumentSigningWorkflowsUpdater
{
    internal static DocumentUpdateParameters Update(Document document, DocumentSigningStatus status)
    {
        DocumentSigningWorkflow currentWorkflow = document.SigningData.Workflows.Last();

        DocumentSigningWorkflowStatus nextSigningWorkflowStatus = GetNextSigningWorkflowStatus(status);

        currentWorkflow.SetStatus(nextSigningWorkflowStatus);

        DocumentStatusTransitionType nextDocumentStatusTransitionType = GetNextDocumentStatusTransitionType(status);

        DocumentStatusTransition nextStatusTransition = document.StatusStateMachine.GetRequiredTransition(document.Status.Id, nextDocumentStatusTransitionType);

        DocumentUpdateParameters result = DocumentUpdateParametersFactory.Create(nextStatusTransition);

        return result;
    }

    private static DocumentSigningWorkflowStatus GetNextSigningWorkflowStatus(DocumentSigningStatus status)
    {
        DocumentSigningWorkflowStatus result = status switch
        {
            DocumentSigningStatus.Signed => DocumentSigningWorkflowStatus.Finished,
            DocumentSigningStatus.Cancelled => DocumentSigningWorkflowStatus.Finished,
            DocumentSigningStatus.ToPreparation => DocumentSigningWorkflowStatus.Finished,
            DocumentSigningStatus.ReturnedToRework => DocumentSigningWorkflowStatus.Finished,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    private static DocumentStatusTransitionType GetNextDocumentStatusTransitionType(DocumentSigningStatus status)
    {
        DocumentStatusTransitionType result = status switch
        {
            DocumentSigningStatus.Signed => DocumentStatusTransitionType.SigningToSigned,
            DocumentSigningStatus.Cancelled => DocumentStatusTransitionType.SigningToCancelled,
            DocumentSigningStatus.ToPreparation => DocumentStatusTransitionType.SigningToPreparation,
            DocumentSigningStatus.ReturnedToRework => DocumentStatusTransitionType.SigningToRework,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
