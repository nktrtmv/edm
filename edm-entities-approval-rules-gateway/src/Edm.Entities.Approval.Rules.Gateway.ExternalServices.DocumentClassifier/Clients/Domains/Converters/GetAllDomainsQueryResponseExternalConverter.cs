using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.DocumentClassifier.Clients.Queries.GetAllDomains.Contracts;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.DocumentClassifier.Clients.Queries.GetAllDomains.Contracts.Domains;

namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.DocumentClassifier.Clients.Domains.Converters;

internal static class GetAllDomainsQueryResponseExternalConverter
{
    internal static GetAllDomainsQueryResponseExternal FromDto(GetAllDomainsV2.Types.Response response)
    {
        ApprovalDomainExternal[] domains = response.Domains.Select(ApprovalDomainExternalConverter.FromDto).ToArray();

        var result = new GetAllDomainsQueryResponseExternal(domains);

        return result;
    }
}
