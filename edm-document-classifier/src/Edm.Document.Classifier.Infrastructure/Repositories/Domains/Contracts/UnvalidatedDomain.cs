using System.Text.Json.Serialization;

using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

namespace Edm.Document.Classifier.Infrastructure.Repositories.Domains.Contracts;

public sealed class UnvalidatedDomain
{
    [JsonPropertyName("$schema")]
    public string? Schema { get; set; }

    public string? Id { get; set; }

    public bool ShowInProduction { get; set; }

    public string? Name { get; set; }

    public DocumentCreationType DocumentCreationType { get; set; }

    public List<UnvalidatedDomainRegistryRole>? RegistryRoles { get; set; }

    public List<UnvalidatedSystemAttribute>? SystemAttributes { get; set; }

    public List<UnvalidatedDocumentRole>? DocumentRoles { get; set; }
    public List<DocumentAction>? DocumentActions { get; set; }

    public UnvalidatedDocumentsSettings? DocumentsSettings { get; set; }

    public UnvalidatedCommentsSettings? CommentsSettings { get; set; }
    public string? UrlAlias { get; set; }
}
