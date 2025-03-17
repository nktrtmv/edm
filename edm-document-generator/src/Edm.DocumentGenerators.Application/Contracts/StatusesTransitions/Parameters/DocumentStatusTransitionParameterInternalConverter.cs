using Edm.DocumentGenerators.Application.Contracts.StatusesTransitions.Parameters.Kinds;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters.Kinds;

namespace Edm.DocumentGenerators.Application.Contracts.StatusesTransitions.Parameters;

internal static class DocumentStatusTransitionParameterInternalConverter
{
    internal static DocumentStatusTransitionParameterInternal FromDomain(DocumentStatusTransitionParameter parameter)
    {
        DocumentStatusTransitionParameterKindInternal kind = DocumentStatusTransitionParameterKindInternalConverter.FromDomain(parameter.Kind);

        var result = new DocumentStatusTransitionParameterInternal(kind);

        return result;
    }

    internal static DocumentStatusTransitionParameter ToDomain(DocumentStatusTransitionParameterInternal parameter)
    {
        DocumentStatusTransitionParameterKind kind = DocumentStatusTransitionParameterKindInternalConverter.ToDomain(parameter.Kind);

        var result = new DocumentStatusTransitionParameter(kind);

        return result;
    }
}
