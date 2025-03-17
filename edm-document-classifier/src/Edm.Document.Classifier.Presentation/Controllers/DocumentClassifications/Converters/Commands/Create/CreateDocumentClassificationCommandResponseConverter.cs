using Edm.Document.Classifier.Application.DocumentClassifications.Commands.Create.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentClassifications.Converters.Commands.Create;

internal static class CreateDocumentClassificationCommandResponseConverter
{
    internal static CreateDocumentClassificationCommandResponse FromInternal(CreateDocumentClassificationCommandInternalResponse response)
    {
        var result = new CreateDocumentClassificationCommandResponse
        {
            DocumentTemplateId = response.DocumentTemplateId
        };

        return result;
    }
}
