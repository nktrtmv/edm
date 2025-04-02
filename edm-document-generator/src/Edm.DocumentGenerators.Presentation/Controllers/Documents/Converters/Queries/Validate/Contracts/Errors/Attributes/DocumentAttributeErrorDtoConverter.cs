using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesErrors;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Validate.Contracts.Errors.Attributes;

public static class DocumentAttributeErrorDtoConverter
{
    public static DocumentAttributeErrorDto FromInternal(DocumentAttributeErrorInternal error)
    {
        var attributeId = IdConverterTo.ToString(error.AttributeId);

        var result = new DocumentAttributeErrorDto
        {
            AttributeId = attributeId,
            Message = error.Message
        };

        return result;
    }
}
