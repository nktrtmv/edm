using Edm.Document.Searcher.Domain.Documents.ValueObjects;

namespace Edm.Document.Searcher.Domain.Documents;

public static class DomainIdHelper
{
    public static string GetDomainIdOrSetDefault(string domainId) => string.IsNullOrWhiteSpace(domainId) ? DomainId.ContractsDomain : domainId;
}
