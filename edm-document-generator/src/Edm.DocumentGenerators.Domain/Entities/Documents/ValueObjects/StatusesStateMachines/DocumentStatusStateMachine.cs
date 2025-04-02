using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines;

public sealed class DocumentStatusStateMachine
{
    internal DocumentStatusStateMachine(DocumentStatusTransition[] transitions)
    {
        Transitions = transitions;
    }

    public DocumentStatusTransition[] Transitions { get; }

    public DocumentStatusTransition[] GetAvailableTransitionsForStatus(Id<DocumentStatus> currentStatusId)
    {
        DocumentStatusTransition[]? result = Transitions.Where(t => t.From.Id == currentStatusId).ToArray();

        return result;
    }

    internal DocumentStatusTransition GetRequiredTransition(Id<DocumentStatus> fromId, DocumentStatusTransitionType type)
    {
        DocumentStatusTransition? result = Transitions.FirstOrDefault(t => t.From.Id == fromId && t.Type == type) ??
            throw new ApplicationException($"Required transition from id {fromId.Value} and type {type} wasn't found");

        return result;
    }

    public DocumentStatusTransition GetRequiredTransition(Id<DocumentStatus> fromId, Id<DocumentStatus> toId)
    {
        DocumentStatusTransition? result = Transitions.FirstOrDefault(t => t.From.Id == fromId && t.To.Id == toId)
            ?? throw new ApplicationException($"Required transition from id {fromId.Value} to id {toId.Value} wasn't found");

        return result;
    }

    public DocumentStatusTransition? GetTransitionOrNull(Id<DocumentStatus> fromId, Id<DocumentStatus> toId)
    {
        DocumentStatusTransition? result = Transitions.FirstOrDefault(t => t.From.Id == fromId && t.To.Id == toId);

        return result;
    }

    internal DocumentStatus GetRequiredStatusById(Id<DocumentStatus> statusId)
    {
        DocumentStatusTransition? fromStatusFound = Transitions.FirstOrDefault(t => t.From.Id == statusId);

        if (fromStatusFound is not null)
        {
            return fromStatusFound.From;
        }

        DocumentStatusTransition? toStatusFound = Transitions.FirstOrDefault(t => t.To.Id == statusId);

        if (toStatusFound is not null)
        {
            return toStatusFound.To;
        }

        throw new BusinessLogicApplicationException($"There is no status (id: {statusId}) found in current state machine.");
    }

    internal DocumentStatus GetRequiredInitialStatus()
    {
        DocumentStatusTransition? transition = Transitions.FirstOrDefault(s => s.From.Type == DocumentStatusType.Initial)
            ?? throw new ApplicationException("Transition with initial type wasn't found");

        DocumentStatus? result = transition.From;

        return result;
    }
}
