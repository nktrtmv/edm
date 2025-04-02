using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates;

public abstract class DocumentTemplateServiceClientBase
{
    protected DocumentTemplateServiceClientBase(DocumentTemplateService.DocumentTemplateServiceClient serviceClient)
    {
        DocumentTemplateServiceClient = serviceClient;
    }

    protected DocumentTemplateService.DocumentTemplateServiceClient DocumentTemplateServiceClient { get; }
}
