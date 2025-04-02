using Edm.DocumentGenerators.Application.Documents.Queries.Validate.Contracts.Errors;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Validate.Contracts.Errors.Attributes;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Validate.Contracts.Errors;

public static class DocumentErrorsDtoConverter
{
    public static DocumentErrorsDto FromInternal(DocumentErrorsInternal errors)
    {
        DocumentAttributeErrorDto[] attributesErrors = errors.AttributesErrors.Select(DocumentAttributeErrorDtoConverter.FromInternal).ToArray();

        var result = new DocumentErrorsDto
        {
            Errors = { errors.Errors },
            AttributesErrors = { attributesErrors }
        };

        return result;
    }
}
