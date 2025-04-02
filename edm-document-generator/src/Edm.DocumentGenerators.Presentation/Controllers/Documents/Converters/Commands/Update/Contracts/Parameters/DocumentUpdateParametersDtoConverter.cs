using Edm.DocumentGenerators.Application.Contracts.Statuses;
using Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues;
using Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters;
using Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.StatusChanges.StatusesTransitionsParametersValues;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.Contracts.AttributesValues;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.Contracts.StatusesTransitionsParametersValues;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.Update.Contracts.Parameters;

internal static class DocumentUpdateParametersDtoConverter
{
    internal static DocumentUpdateParametersInternal ToInternal(DocumentUpdateParametersDto parameters)
    {
        Id<DocumentStatusInternal> statusId = IdConverterFrom<DocumentStatusInternal>.FromString(parameters.StatusId);

        DocumentAttributeValueInternal[] attributesValues =
            parameters.AttributesValues.Select(DocumentAttributeValueDtoConverter.ToInternal).ToArray();

        DocumentStatusTransitionParameterValueInternal[] statusTransitionParametersValues =
            parameters.StatusTransitionParametersValues.Select(DocumentStatusTransitionParameterValueDtoConverter.ToInternal).ToArray();

        var result = new DocumentUpdateParametersInternal(statusId, attributesValues, statusTransitionParametersValues);

        return result;
    }
}
