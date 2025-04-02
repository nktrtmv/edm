using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts;

namespace Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx;

public interface IEntitiesSigningEdxClient
{
    Task SendDocuments(SendSigningEdxDocumentsCommandExternal request, CancellationToken cancellationToken);
}
