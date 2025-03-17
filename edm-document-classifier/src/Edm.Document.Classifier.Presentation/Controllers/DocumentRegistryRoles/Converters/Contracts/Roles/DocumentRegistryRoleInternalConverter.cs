using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentRegistryRoles.Converters.Contracts.Roles.Kinds;
using Edm.Document.Classifier.Presentation.Controllers.DocumentRegistryRoles.Converters.Contracts.Roles.Types;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentRegistryRoles.Converters.Contracts.Roles;

internal static class DocumentRegistryRoleInternalConverter
{
    internal static DocumentRegistryRoleDto ToDto(DomainRegistryRoleInternal role)
    {
        DocumentRegistryRoleTypeDto type = DocumentRegistryRoleTypeDtoFromInternalConverter.FromInternal(role, role.Type);

        DocumentRegistryRoleKindDto kind = DocumentRegistryRoleKindDtoConverter.FromInternal(role.Kind);

        var result = new DocumentRegistryRoleDto
        {
            Id = role.Id,
            DisplayName = role.DisplayName,
            Type = type,
            Kind = kind,
            SystemName = role.SystemName ?? "",
            Name = role.Name,
        };

        return result;
    }
}
