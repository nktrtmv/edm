using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters.Kinds;

namespace Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters;

public sealed class DocumentStatusTransitionParameter
{
    public DocumentStatusTransitionParameter(DocumentStatusTransitionParameterKind kind)
    {
        Kind = kind;
    }

    public DocumentStatusTransitionParameterKind Kind { get; }

    public override string ToString()
    {
        return $"{{ Kind: {Kind} }}";
    }
}
