using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains;
using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

namespace Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts;

public sealed record DocumentDomainInternal(
    string Id,
    string Name,
    DocumentCreationType DocumentCreationType,
    DocumentSettingsInternal DocumentSettings,
    CommentsSettingsInternal CommentsSettings,
    string UrlAlias);
