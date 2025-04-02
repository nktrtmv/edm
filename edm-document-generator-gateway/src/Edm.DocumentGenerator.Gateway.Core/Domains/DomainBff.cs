namespace Edm.DocumentGenerator.Gateway.Core.Domains;

public sealed record DomainBff(
    string Id,
    string Display,
    DomainDocumentCreationType DocumentCreationType,
    DocumentsSettingsBff DocumentsSetting,
    CommentsSettingsBff CommentsSettings,
    string UrlAlias);
