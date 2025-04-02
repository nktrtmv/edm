using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues;

public abstract class DocumentStatusTransitionParameterValue
{
    protected DocumentStatusTransitionParameterValue(DocumentStatusTransitionParameter parameter)
    {
        Parameter = parameter;
    }

    public DocumentStatusTransitionParameter Parameter { get; }

    protected string BaseToString()
    {
        return $"Type: {GetType().Name} Parameter: {Parameter}";
    }
}
