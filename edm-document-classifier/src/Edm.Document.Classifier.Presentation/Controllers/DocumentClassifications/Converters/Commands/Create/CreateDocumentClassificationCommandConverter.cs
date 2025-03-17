using Edm.Document.Classifier.Application.DocumentClassifications.Commands.Create.Contracts;
using Edm.Document.Classifier.Application.DocumentClassifications.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentClassifications.Converters.Converters.Subsets;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentClassifications.Converters.Commands.Create;

internal static class CreateDocumentClassificationCommandConverter
{
    internal static CreateDocumentClassificationCommandInternal ToInternal(CreateDocumentClassificationCommand command)
    {
        DocumentClassifierSubsetInternal classifierSubset = DocumentClassifierSubsetDtoConverter.ToInternal(command.ClassifierSubset);

        var result = new CreateDocumentClassificationCommandInternal(command.Name, classifierSubset);

        return result;
    }
}
