using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.DocumentClassifier.Clients.Domains.Converters;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.DocumentClassifier.Clients.Queries.GetAllDomains.Contracts;

namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.DocumentClassifier.Clients.Domains;

internal sealed class DocumentClassifierDomainsClient(DocumentRegistryRolesService.DocumentRegistryRolesServiceClient domainsClient) : IDocumentClassifierDomainsClient
{
    public async Task<GetAllDomainsQueryResponseExternal> GetAllDomains(CancellationToken cancellationToken)
    {
        var query = new GetAllDomainsV2.Types.Query();

        var response = await domainsClient.GetAllDomainsV2Async(query, cancellationToken: cancellationToken);

        var result = GetAllDomainsQueryResponseExternalConverter.FromDto(response);

        return result;
    }
}
