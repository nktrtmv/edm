using Edm.DocumentGenerators.ExternalServices.DocumentsNotifier.Requests.Contracts;

namespace Edm.DocumentGenerators.ExternalServices.DocumentsNotifier;

public interface IDocumentNotifierRequestsSender
{
    Task Send(DocumentNotifierRequestExternal request, CancellationToken cancellationToken);
}
