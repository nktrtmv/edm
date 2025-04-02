using Edm.Entities.Approval.Rules.Gateway.Core.Domains.Queries.GetAll.Contracts.Domains;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Domains.Queries.GetAll.Contracts;

public sealed class GetAllApprovalDomainsQueryResponseBff
{
    public required ApprovalDomainBff[] Domains { get; init; }
}
