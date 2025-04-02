using Edm.Entities.Approval.Rules.Gateway.ExternalServices.DocumentClassifier.Clients.Queries.GetAllDomains.Contracts.Domains;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Domains.Queries.GetAll.Contracts.Domains;

internal static class ApprovalDomainBffConverter
{
    internal static ApprovalDomainBff FromDto(ApprovalDomainExternal domain)
    {
        var result = new ApprovalDomainBff
        {
            Id = domain.Id,
            DisplayName = domain.DisplayName
        };

        return result;
    }
}
