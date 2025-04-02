using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesErrors;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Errors;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Validate.Contracts.Errors;

internal static class DocumentErrorsInternalConverter
{
    internal static DocumentErrorsInternal FromDomain(DocumentErrors errors)
    {
        DocumentAttributeErrorInternal[] attributes = errors.AttributesErrors.Select(DocumentAttributeErrorInternalConverter.FromDomain).ToArray();

        var result = new DocumentErrorsInternal(errors.Errors, attributes);

        return result;
    }
}
