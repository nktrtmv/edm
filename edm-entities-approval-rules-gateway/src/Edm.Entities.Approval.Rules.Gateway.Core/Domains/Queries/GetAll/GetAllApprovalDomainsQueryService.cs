using Edm.Entities.Approval.Rules.Gateway.Core.Domains.Queries.GetAll.Contracts;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.DocumentClassifier.Clients;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Domains.Queries.GetAll;

public sealed class GetAllApprovalDomainsQueryService(IDocumentClassifierDomainsClient domains)
{
    private IDocumentClassifierDomainsClient Domains { get; } = domains;

    public async Task<GetAllApprovalDomainsQueryResponseBff> GetAll(
        GetAllApprovalDomainsQueryBff _,
        CancellationToken cancellationToken)
    {
        var response = await Domains.GetAllDomains(cancellationToken);

        var result = GetAllApprovalDomainsQueryResponseBffConverter.FromDto(response);

        return result;
    }
}
