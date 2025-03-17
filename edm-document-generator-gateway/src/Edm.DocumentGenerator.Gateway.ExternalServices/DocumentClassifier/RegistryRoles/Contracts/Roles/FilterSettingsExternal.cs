namespace Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles;

public sealed record FilterSettingsExternal(
    bool AllowForSearch,
    bool ShowInFilters,
    bool AllowFilterMultipleValues,
    int SearchKind,
    long? Order);
