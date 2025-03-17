using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Converters.Roles.Kinds;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Converters.Roles.Types;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Converters.Roles;

internal static class DocumentRegistryRoleDtoConverter
{
    internal static DocumentRegistryRoleExternal ToExternal(DocumentRegistryRoleDto role)
    {
        var type = DocumentRegistryRoleTypeExternalFromDomainConverter.FromDto(role.Type);

        var kind = DocumentRegistryRoleKindExternalConverter.FromDto(role.Kind);

        var filterSettings = new FilterSettingsExternal(
            role.Type.FilterSettings.AllowForSearch,
            role.Type.FilterSettings.ShowInFilters,
            role.Type.FilterSettings.AllowMultipleValues,
            (int)role.Type.FilterSettings.SearchKind,
            role.Type.FilterSettings.Order);

        var registrySettings = new RegistrySettingsExternal(
            role.Type.RegistrySettings.ShowInRegistry,
            role.Type.RegistrySettings.ShowByDefault);

        var result = new DocumentRegistryRoleExternal(
            role.Id,
            role.Name,
            role.DisplayName,
            role.SystemName,
            filterSettings,
            registrySettings,
            type,
            kind);

        return result;
    }
}
