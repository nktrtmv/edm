using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.Services.Validators.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.Services.Validators;

internal sealed class StateMachineRequiredSigningTransitionsValidator : StateMachineValidator
{
    private static readonly DocumentStatusTransitionType[] RequiredTransitions =
    {
        DocumentStatusTransitionType.SigningToSigned,
        DocumentStatusTransitionType.SigningToCancelled,
        DocumentStatusTransitionType.SigningToPreparation,
        DocumentStatusTransitionType.SigningToRework
    };

    private static void ValidateRequiredTransitions(DocumentStatusTransition[] transitions)
    {
        foreach (DocumentStatusTransitionType requiredTransitionType in RequiredTransitions)
        {
            int requiredTransitionCount = transitions.Count(t => t.Type == requiredTransitionType);

            if (requiredTransitionCount != 1)
            {
                throw new BusinessLogicApplicationException($"Signing status require outgoing transition of type: '{requiredTransitionType}').");
            }
        }
    }

    internal override void Validate(Dictionary<DocumentStatus, DocumentStatusTransition[]> transitionsByFromStatus)
    {
        DocumentStatusTransition[][] transitionsFromSigningStatuses = transitionsByFromStatus
            .Where(s => s.Key.Type == DocumentStatusType.Signing)
            .Select(t => t.Value)
            .ToArray();

        foreach (DocumentStatusTransition[] transitionsFromSigningStatus in transitionsFromSigningStatuses)
        {
            ValidateRequiredTransitions(transitionsFromSigningStatus);
        }
    }
}
