namespace Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles;

public sealed record FilterSettingsBff(bool AllowForSearch, bool ShowInFilters, bool AllowMultipleValues, SearchKindBff SearchKind, long? Order);
