using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesErrors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Errors.AttributesErrors;

internal static class DocumentAttributeErrorDbConverter
{
    internal static DocumentAttributeErrorDb FromDomain(DocumentAttributeError attributeError)
    {
        var attributeId = IdConverterTo.ToString(attributeError.AttributeId);

        var result = new DocumentAttributeErrorDb
        {
            AttributeId = attributeId,
            Message = attributeError.Message
        };

        return result;
    }

    internal static DocumentAttributeError ToDomain(DocumentAttributeErrorDb error)
    {
        Id<DocumentAttribute> attributeId = IdConverterFrom<DocumentAttribute>.FromString(error.AttributeId);

        var result = new DocumentAttributeError(attributeId, error.Message);

        return result;
    }
}
