using Edm.DocumentGenerators.Application.Documents.Commands.Contracts.Classifications;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.CreateByClassification.Contracts.Classifications;

internal static class CreateByClassificationDocumentsCommandClassificationConverter
{
    internal static DocumentClassificationInternal ToInternal(CreateByClassificationDocumentsCommandClassification classification)
    {
        var result = new DocumentClassificationInternal(
            classification.BusinessSegmentId,
            classification.DocumentCategoryId,
            classification.DocumentTypeId,
            classification.DocumentKindId);

        return result;
    }
}
