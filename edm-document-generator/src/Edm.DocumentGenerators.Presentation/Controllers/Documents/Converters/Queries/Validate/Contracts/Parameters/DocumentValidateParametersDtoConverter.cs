using Edm.DocumentGenerators.Application.Contracts.Statuses;
using Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues;
using Edm.DocumentGenerators.Application.Documents.Queries.Validate.Contracts.Parameters;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.Contracts.AttributesValues;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Validate.Contracts.Parameters;

internal static class DocumentValidateParametersDtoConverter
{
    internal static DocumentValidateParametersInternal ToInternal(DocumentValidateParametersDto parameters)
    {
        Id<DocumentStatusInternal> statusId =
            IdConverterFrom<DocumentStatusInternal>.FromString(parameters.StatusId);

        DocumentAttributeValueInternal[] attributesValues =
            parameters.AttributesValues.Select(DocumentAttributeValueDtoConverter.ToInternal).ToArray();

        var result = new DocumentValidateParametersInternal(statusId, attributesValues);

        return result;
    }
}
