using Edm.Entities.Approval.Rules.Gateway.ExternalServices.DocumentClassifier.Clients.Queries.GetAllDomains.Contracts.Domains;

namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.DocumentClassifier.Clients.Queries.GetAllDomains.Contracts;

public sealed record GetAllDomainsQueryResponseExternal(ApprovalDomainExternal[] Domains);
