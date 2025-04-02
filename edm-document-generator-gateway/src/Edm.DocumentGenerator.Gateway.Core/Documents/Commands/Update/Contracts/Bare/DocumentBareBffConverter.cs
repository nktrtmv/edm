using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.AttributesValues;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.StatusTransitionParametersValues;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare;

internal static class DocumentBareBffConverter
{
    public static DocumentUpdateParametersDto ToUpdateParametersDto(
        DocumentBareBff document,
        DocumentStatusTransitionParameterValueBff[] statusTransitionParametersValuesBff)
    {
        DocumentAttributeValueDto[] attributeValues = document
            .AttributesValues
            .Select(DocumentAttributeValueBareBffConverter.ToDto)
            .ToArray();

        DocumentStatusTransitionParameterValueDto[] statusTransitionParametersValues = statusTransitionParametersValuesBff
            .Select(DocumentStatusTransitionParameterValueBffToDtoConverter.ToDto)
            .ToArray();

        var result = new DocumentUpdateParametersDto
        {
            StatusId = document.StatusId,
            AttributesValues = { attributeValues },
            StatusTransitionParametersValues = { statusTransitionParametersValues }
        };

        return result;
    }

    public static DocumentValidateParametersDto ToValidationParametersDto(DocumentBareBff document)
    {
        DocumentAttributeValueDto[] attributeValues =
            document.AttributesValues.Select(DocumentAttributeValueBareBffConverter.ToDto).ToArray();

        var result = new DocumentValidateParametersDto
        {
            StatusId = document.StatusId,
            AttributesValues = { attributeValues }
        };

        return result;
    }
}
