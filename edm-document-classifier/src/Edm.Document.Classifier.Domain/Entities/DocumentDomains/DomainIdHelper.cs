using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

namespace Edm.Document.Classifier.Domain.Entities.DocumentDomains;

public static class DomainIdHelper
{
    public static string GetDomainIdOrSetDefault(string? domainId) => string.IsNullOrWhiteSpace(domainId)
        ? DomainId.Contracts.Value
        : domainId;
}
