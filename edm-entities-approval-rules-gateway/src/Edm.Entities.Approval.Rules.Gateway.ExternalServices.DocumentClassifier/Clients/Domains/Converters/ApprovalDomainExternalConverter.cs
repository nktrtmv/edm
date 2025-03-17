using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.DocumentClassifier.Clients.Queries.GetAllDomains.Contracts.Domains;

namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.DocumentClassifier.Clients.Domains.Converters;

internal static class ApprovalDomainExternalConverter
{
    internal static ApprovalDomainExternal FromDto(DomainDto domain)
    {
        var result = new ApprovalDomainExternal
        {
            Id = domain.DomainId,
            DisplayName = domain.DomainName
        };

        return result;
    }
}
