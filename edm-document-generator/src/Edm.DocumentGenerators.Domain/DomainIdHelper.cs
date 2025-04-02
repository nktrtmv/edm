using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;

namespace Edm.DocumentGenerators.Domain;

public static class DomainIdHelper
{
    public static string GetDomainIdOrSetDefault(string? domainId)
    {
        return string.IsNullOrWhiteSpace(domainId) ? DomainId.Contracts : domainId;
    }
}
