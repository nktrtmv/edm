using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Services.Validators.Changes.StatusChanges.Transitions;

public static class TransitionExistsAmongAvailableTransitionsValidator
{
    internal static void Validate(DocumentStatusTransition statusTransition, Document document)
    {
        DocumentStatusTransition[] availableTransitions = document.StatusStateMachine.GetAvailableTransitionsForStatus(document.Status.Id);

        int transitionsCount = availableTransitions.Count(t => t.Id == statusTransition.Id);

        if (transitionsCount != 1)
        {
            throw new BusinessLogicApplicationException(
                $"""
                 Expected transition should exist among available transitions but there are {transitionsCount} such transition(s) found.
                 DocumentId: {document.Id}
                 StatusTransitionId: {statusTransition.Id}
                 """);
        }
    }
}
