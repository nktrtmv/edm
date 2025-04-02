using Edm.DocumentGenerators.Application.Contracts.StatusesTransitions.Parameters;
using Edm.DocumentGenerators.Application.Contracts.StatusesTransitions.Parameters.Kinds;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.StatusesTransitions.Parameters.Kinds;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.StatusesTransitions.Parameters;

internal static class DocumentStatusTransitionParameterDtoConverter
{
    internal static DocumentStatusTransitionParameterDto FromInternal(DocumentStatusTransitionParameterInternal parameter)
    {
        DocumentStatusTransitionParameterKindDto kind = DocumentStatusTransitionParameterKindDtoConverter.FromInternal(parameter.Kind);

        var result = new DocumentStatusTransitionParameterDto
        {
            Kind = kind
        };

        return result;
    }

    internal static DocumentStatusTransitionParameterInternal ToInternal(DocumentStatusTransitionParameterDto parameter)
    {
        DocumentStatusTransitionParameterKindInternal kind = DocumentStatusTransitionParameterKindDtoConverter.ToInternal(parameter.Kind);

        var result = new DocumentStatusTransitionParameterInternal(kind);

        return result;
    }
}
