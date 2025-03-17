using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsSystemAttributes;

public abstract class DocumentSystemAttributesServiceClientBase
{
    protected DocumentSystemAttributesServiceClientBase(DocumentSystemAttributesService.DocumentSystemAttributesServiceClient systemAttributesService)
    {
        SystemAttributesService = systemAttributesService;
    }

    protected DocumentSystemAttributesService.DocumentSystemAttributesServiceClient SystemAttributesService { get; }
}
