using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;
using Edm.Document.Classifier.GenericSubdomain.Exceptions;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentRegistryRoles.Converters.Contracts.Roles.Kinds;

internal static class DocumentRegistryRoleKindDtoConverter
{
    internal static DocumentRegistryRoleKindDto FromInternal(DocumentRegistryRoleKind kind)
    {
        DocumentRegistryRoleKindDto result = kind switch
        {
            DocumentRegistryRoleKind.Attribute => DocumentRegistryRoleKindDto.Attribute,
            DocumentRegistryRoleKind.ComputedProperty => DocumentRegistryRoleKindDto.ComputedProperty,
            DocumentRegistryRoleKind.Watchers => DocumentRegistryRoleKindDto.Watchers,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }
}
