using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.Services.Validators.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.Services.Validators;

internal sealed class StateMachineAllRoutesAreFinalizedValidator : StateMachineValidator
{
    internal override void Validate(Dictionary<DocumentStatus, DocumentStatusTransition[]> transitionsByFromStatus)
    {
        var pendingStatuses = new Queue<DocumentStatus>();
        var passedStatuses = new HashSet<DocumentStatus>();

        DocumentStatus initialStatus = transitionsByFromStatus.Keys.Single(x => x.Type == DocumentStatusType.Initial);

        pendingStatuses.Enqueue(initialStatus);

        while (pendingStatuses.Any())
        {
            DocumentStatus currentStatus = pendingStatuses.Dequeue();

            passedStatuses.Add(currentStatus);

            DocumentStatusTransition[]? possibleTransitions = transitionsByFromStatus.GetValueOrDefault(currentStatus);

            if (possibleTransitions == null)
            {
                if (currentStatus.Type != DocumentStatusType.Completed && currentStatus.Type != DocumentStatusType.Cancelled)
                {
                    throw new BusinessLogicApplicationException(
                        $"All routes shall be finalized with '{DocumentStatusType.Completed}' or '{DocumentStatusType.Cancelled}' status (current status type: '{currentStatus.Type}')");
                }

                continue;
            }

            foreach (DocumentStatusTransition transition in possibleTransitions)
            {
                if (!passedStatuses.Contains(transition.To))
                {
                    pendingStatuses.Enqueue(transition.To);
                }
            }
        }
    }
}
