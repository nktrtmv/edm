using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Contracts.Roles.Kinds;
using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Contracts.Roles.Types;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Contracts.Roles;

internal static class DocumentRegistryRoleBffConverter
{
    public static DocumentRegistryRoleBff FromExternal(DocumentRegistryRoleExternal role)
    {
        var type = DocumentRegistryRoleTypeBffConverter.ToBff(role.Type);

        var kind = DocumentRegistryRoleKindBffConverter.FromExternal(role.Kind);

        var filterSettings = new FilterSettingsBff(
            role.FilterSettings.AllowForSearch,
            role.FilterSettings.ShowInFilters,
            role.FilterSettings.AllowFilterMultipleValues,
            (SearchKindBff)role.FilterSettings.SearchKind,
            role.FilterSettings.Order);

        var registrySettings = new RegistrySettingsBff(
            role.RegistrySettings.ShowInRegistry,
            role.RegistrySettings.ShowByDefault);

        var result = new DocumentRegistryRoleBff
        {
            Id = role.Name,
            EnumIntValue = role.Id,
            DisplayName = role.DisplayName,
            Type = type,
            Kind = kind,
            FilterSettings = filterSettings,
            RegistrySettings = registrySettings
        };

        return result;
    }
}
