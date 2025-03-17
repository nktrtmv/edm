// ReSharper disable ArrangeMethodOrOperatorBody

using Edm.Entities.Approval.Rules.Domain.Entities.Domains.ValueObjects;

namespace Edm.Entities.Approval.Rules.Domain;

public static class DomainIdHelper
{
    public static string GetDomainIdOrSetDefault(string domainId) => string.IsNullOrWhiteSpace(domainId)
        ? DomainId.ContractsDomain
        : domainId;
}
