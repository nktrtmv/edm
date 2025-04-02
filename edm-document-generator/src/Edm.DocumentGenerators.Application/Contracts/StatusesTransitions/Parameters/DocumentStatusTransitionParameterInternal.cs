using Edm.DocumentGenerators.Application.Contracts.StatusesTransitions.Parameters.Kinds;

namespace Edm.DocumentGenerators.Application.Contracts.StatusesTransitions.Parameters;

public sealed class DocumentStatusTransitionParameterInternal
{
    public DocumentStatusTransitionParameterInternal(DocumentStatusTransitionParameterKindInternal kind)
    {
        Kind = kind;
    }

    public DocumentStatusTransitionParameterKindInternal Kind { get; }
}
