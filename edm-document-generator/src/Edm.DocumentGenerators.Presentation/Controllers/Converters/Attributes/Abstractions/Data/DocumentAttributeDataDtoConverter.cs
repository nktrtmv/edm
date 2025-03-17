using Edm.DocumentGenerators.Application.Contracts;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions.Data;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Contracts.ApprovalData;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Contracts.Permissions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.LinksKinds;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Attributes.ApprovalData;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Attributes.DocumentsLinks.Kinds;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Attributes.Permissions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Attributes.Abstractions.Data;

internal static class DocumentAttributeDataDtoConverter
{
    internal static DocumentAttributeDataDto FromInternal(DocumentAttributeDataInternal data)
    {
        var frontMetadata = MetadataConverterTo.ToString(data.FrontMetadata);

        bool isApprovalParticipant = DocumentAttributeApprovalDataDtoConverter.FromInternal(data.ApprovalData);

        DocumentAttributePermissionDto[] permissions = data.Permissions.Select(DocumentAttributePermissionDtoConverter.FromInternal).ToArray();

        DocumentLinkKindDto? linkKind = NullableConverter.Convert(data.LinkKind, DocumentLinkKindDtoConverter.FromInternal);

        var result = new DocumentAttributeDataDto
        {
            Id = data.Id,
            IsArray = data.IsArray,
            FrontMetadata = frontMetadata,
            IsApprovalParticipant = isApprovalParticipant,
            Permissions = { permissions },
            DocumentsRoles = { data.DocumentsRoles },
            RegistryRoles = { data.RegistryRoles },
            SystemName = data.SystemName,
            DisplayName = data.DisplayName
        };

        if (linkKind is not null)
        {
            result.LinkKind = linkKind.Value;
        }

        return result;
    }

    internal static DocumentAttributeDataInternal ToInternal(DocumentAttributeDataDto data)
    {
        Metadata<FrontInternal> frontMetadata = MetadataConverterFrom<FrontInternal>.FromString(data.FrontMetadata);

        DocumentAttributeApprovalDataInternal approvalData = DocumentAttributeApprovalDataDtoConverter.ToInternal(data.IsApprovalParticipant);

        DocumentAttributePermissionInternal[] permissions = data.Permissions.Select(DocumentAttributePermissionDtoConverter.ToInternal).ToArray();

        int[] registryRoles = data.RegistryRoles.ToArray();

        DocumentLinkKind? linkKind = data.HasLinkKind
            ? DocumentLinkKindDtoConverter.ToInternal(data.LinkKind)
            : null;

        var result = new DocumentAttributeDataInternal(
            data.Id,
            data.IsArray,
            frontMetadata,
            approvalData,
            permissions,
            data.DocumentsRoles.ToArray(),
            registryRoles,
            linkKind,
            data.SystemName,
            data.DisplayName);

        return result;
    }
}
