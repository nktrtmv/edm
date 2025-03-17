using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.ValueObjects.StatusChanges;

public sealed class DocumentStatusChange
{
    public DocumentStatusChange(DocumentStatusTransition transition, params DocumentStatusTransitionParameterValue[] statusTransitionParametersValues)
    {
        Transition = transition;
        StatusTransitionParametersValues = statusTransitionParametersValues;
    }

    public DocumentStatusTransition Transition { get; }
    internal DocumentStatusTransitionParameterValue[] StatusTransitionParametersValues { get; }

    public override string ToString()
    {
        string statusTransitionParametersValues =
            string.Join<DocumentStatusTransitionParameterValue>(", ", StatusTransitionParametersValues);

        return $"{{ Transition: {Transition}, statusTransitionParametersValues: [{statusTransitionParametersValues}] }}";
    }
}
