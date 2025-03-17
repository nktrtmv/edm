using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles.Kinds;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Converters.Roles.Kinds;

internal static class DocumentRegistryRoleKindExternalConverter
{
    internal static DocumentRegistryRoleKindExternal FromDto(DocumentRegistryRoleKindDto kind)
    {
        var result = kind switch
        {
            DocumentRegistryRoleKindDto.Attribute => DocumentRegistryRoleKindExternal.Attribute,

            DocumentRegistryRoleKindDto.ComputedProperty => DocumentRegistryRoleKindExternal.ComputedProperty,

            DocumentRegistryRoleKindDto.Watchers => DocumentRegistryRoleKindExternal.Watchers,

            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }
}
