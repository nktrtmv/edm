using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.Services.Validators.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.Services.Validators;

internal sealed class StateMachineHasOneInitialStatusValidator : StateMachineValidator
{
    internal override void Validate(Dictionary<DocumentStatus, DocumentStatusTransition[]> transitionsByFromStatus)
    {
        int initialStatusCount = transitionsByFromStatus.Keys.Count(t => t.Type == DocumentStatusType.Initial);

        if (initialStatusCount != 1)
        {
            throw new BusinessLogicApplicationException($"Exactly one initial status shall be defined but found {initialStatusCount} times.");
        }
    }
}
