using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.Services.Validators.Abstractions;

internal abstract class StateMachineValidator
{
    internal abstract void Validate(Dictionary<DocumentStatus, DocumentStatusTransition[]> transitionsByFromStatus);
}
