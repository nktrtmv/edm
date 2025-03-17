using Edm.Document.Classifier.Domain.Extensions;

namespace Edm.Document.Classifier.Domain.Entities.DocumentDomains;

public sealed class DocumentDomains
{
    private DocumentDomains(List<DocumentDomain> documentDomains)
    {
        Value = documentDomains;
    }

    public List<DocumentDomain> Value { get; private set; }

    public static DocumentDomains Parse(List<DocumentDomain> domains)
    {
        domains
            .Select(x => x.Id.Value)
            .ToList()
            .ThrowIfNonAllUnique(() => "All domains must have unique id");

        domains
            .Select(x => x.Name.Value)
            .ToList()
            .ThrowIfNonAllUnique(() => "All domains must have unique name");

        domains = domains.OrderBy(x => x.Name.Value).ToList();

        var result = new DocumentDomains(domains);

        return result;
    }
}
