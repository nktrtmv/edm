using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.Services;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.Factories;

public static class DocumentStatusStateMachineFactory
{
    public static DocumentStatusStateMachine CreateFrom(DocumentStatusTransition[] transitions)
    {
        DocumentStatusStateMachineValidator.Validate(transitions);

        var result = new DocumentStatusStateMachine(transitions);

        return result;
    }

    public static DocumentStatusStateMachine CreateFromDb(params DocumentStatusTransition[] transitions)
    {
        var result = new DocumentStatusStateMachine(transitions);

        return result;
    }
}
