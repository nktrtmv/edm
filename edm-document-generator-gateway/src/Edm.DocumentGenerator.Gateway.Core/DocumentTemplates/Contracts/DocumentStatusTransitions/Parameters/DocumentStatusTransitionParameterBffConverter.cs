using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentStatusTransitions.Parameters.Kinds;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentStatusTransitions.Parameters;

internal static class DocumentStatusTransitionParameterBffConverter
{
    public static DocumentStatusTransitionParameterBff FromDto(DocumentStatusTransitionParameterDto dto)
    {
        var kind = DocumentStatusTransitionParameterKindBffConverter.FromDto(dto.Kind);

        var result = new DocumentStatusTransitionParameterBff
        {
            Kind = kind
        };

        return result;
    }

    public static DocumentStatusTransitionParameterDto ToDto(DocumentStatusTransitionParameterBff bff)
    {
        var kind = DocumentStatusTransitionParameterKindBffConverter.ToDto(bff.Kind);

        var result = new DocumentStatusTransitionParameterDto
        {
            Kind = kind
        };

        return result;
    }
}
