using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles.Kinds;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Contracts.Roles.Kinds;

internal static class DocumentRegistryRoleKindBffConverter
{
    internal static DocumentRegistryRoleKindBff FromExternal(DocumentRegistryRoleKindExternal kind)
    {
        var result = kind switch
        {
            DocumentRegistryRoleKindExternal.Attribute => DocumentRegistryRoleKindBff.Attribute,
            DocumentRegistryRoleKindExternal.ComputedProperty => DocumentRegistryRoleKindBff.Property,
            DocumentRegistryRoleKindExternal.Watchers => DocumentRegistryRoleKindBff.Watchers,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }
}
