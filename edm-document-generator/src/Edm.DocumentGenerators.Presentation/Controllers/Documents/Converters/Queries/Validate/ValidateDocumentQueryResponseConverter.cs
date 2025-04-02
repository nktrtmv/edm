using Edm.DocumentGenerators.Application.Documents.Queries.Validate.Contracts;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.AttributesValues;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Validate.Contracts.Errors;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Validate.Contracts.Results;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Validate;

internal static class ValidateDocumentQueryResponseConverter
{
    internal static ValidateDocumentQueryResponse FormInternal(ValidateDocumentQueryInternalResponse response)
    {
        DocumentValidatorValidationResultDto[] validationResults =
            response.ValidationResults.Select(DocumentValidationResultDtoConverter.FromInternal).ToArray();

        DocumentErrorsDto documentErrors = DocumentErrorsDtoConverter.FromInternal(response.DocumentErrors);

        DocumentAttributeValueDetailedDto[] updatedAttributeValues =
            response.UpdatedAttributeValues.Select(DocumentAttributeValueDetailedDtoFromInternalConverter.FromInternal).ToArray();

        var result = new ValidateDocumentQueryResponse
        {
            DocumentValidatorsValidationResults = { validationResults },
            DocumentErrors = documentErrors,
            UpdatedAttributesValues = { updatedAttributeValues }
        };

        return result;
    }
}
