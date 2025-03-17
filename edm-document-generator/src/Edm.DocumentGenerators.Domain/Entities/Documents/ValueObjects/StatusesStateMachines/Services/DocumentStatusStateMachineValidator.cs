using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.Services.Validators;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.Services.Validators.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.Services;

internal static class DocumentStatusStateMachineValidator
{
    private static readonly StateMachineValidator[] Validators =
    {
        new StateMachineHasOneInitialStatusValidator(),
        new StateMachineAllRoutesAreFinalizedValidator(),
        new StateMachineRequiredApprovalTransitionsValidator(),
        new StateMachineRequiredSigningTransitionsValidator()
    };

    internal static void Validate(DocumentStatusTransition[] transitions)
    {
        Dictionary<DocumentStatus, DocumentStatusTransition[]> transitionsByFromStatus = transitions
            .GroupBy(t => t.From)
            .ToDictionary(
                t => t.Key,
                t => t.ToArray());

        foreach (StateMachineValidator validator in Validators)
        {
            validator.Validate(transitionsByFromStatus);
        }
    }
}
