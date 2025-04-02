using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesErrors;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesErrors;

internal static class DocumentAttributeErrorInternalConverter
{
    internal static DocumentAttributeErrorInternal FromDomain(DocumentAttributeError error)
    {
        Id<DocumentAttributeInternal> attributeId = IdConverterFrom<DocumentAttributeInternal>.From(error.AttributeId);

        var result = new DocumentAttributeErrorInternal(attributeId, error.Message);

        return result;
    }
}
