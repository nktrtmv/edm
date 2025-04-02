using Edm.Entities.Approval.Rules.Gateway.Core.Domains.Queries.GetAll.Contracts.Domains;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.DocumentClassifier.Clients.Queries.GetAllDomains.Contracts;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Domains.Queries.GetAll.Contracts;

internal static class GetAllApprovalDomainsQueryResponseBffConverter
{
    internal static GetAllApprovalDomainsQueryResponseBff FromDto(GetAllDomainsQueryResponseExternal response)
    {
        ApprovalDomainBff[] domains = response.Domains.Select(ApprovalDomainBffConverter.FromDto).ToArray();

        var result = new GetAllApprovalDomainsQueryResponseBff
        {
            Domains = domains
        };

        return result;
    }
}
