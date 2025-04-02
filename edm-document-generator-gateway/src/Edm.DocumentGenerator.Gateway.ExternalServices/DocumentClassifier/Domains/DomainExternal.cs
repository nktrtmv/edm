namespace Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.Domains;

public sealed record DomainExternal(
    string Id,
    string Name,
    int DocumentCreationType,
    DocumentsSettingsExternal DocumentsSettings,
    CommentsSettingsExternal CommentsSettings,
    string UrlAlias);
