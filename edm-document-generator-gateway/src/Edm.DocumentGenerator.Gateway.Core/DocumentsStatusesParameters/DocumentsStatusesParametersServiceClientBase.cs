using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsStatusesParameters;

public abstract class DocumentsStatusesParametersServiceClientBase
{
    protected DocumentsStatusesParametersServiceClientBase(DocumentsStatusesParametersService.DocumentsStatusesParametersServiceClient serviceClient)
    {
        ServiceClient = serviceClient;
    }

    protected DocumentsStatusesParametersService.DocumentsStatusesParametersServiceClient ServiceClient { get; }
}
