using Edm.DocumentGenerators.Application.Contracts.Attributes.Contracts.ApprovalData;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Contracts.Permissions;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions.Data;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions.Data.Factories;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.ApprovalData;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.Permissions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions.Data;

internal static class DocumentAttributeDataInternalConverter
{
    internal static DocumentAttributeDataInternal FromDomain(DocumentAttributeData data)
    {
        var id = IdConverterTo.ToString(data.Id);

        Metadata<FrontInternal> frontMetadata = MetadataConverterFrom<FrontInternal>.From(data.FrontMetadata);

        DocumentAttributeApprovalDataInternal approvalData = DocumentAttributeApprovalDataInternalConverter.FromDomain(data.ApprovalData);

        DocumentAttributePermissionInternal[] permissions = data.Permissions.Select(DocumentAttributePermissionInternalConverter.FromDomain).ToArray();

        var result = new DocumentAttributeDataInternal(
            id,
            data.IsArray,
            frontMetadata,
            approvalData,
            permissions,
            data.DocumentsRoles,
            data.RegistryRoles,
            data.LinkKind,
            data.SystemName?.Value ?? "",
            data.DisplayName);

        return result;
    }

    internal static DocumentAttributeData ToDomain(DocumentAttributeDataInternal data)
    {
        Id<DocumentAttribute> id = IdConverterFrom<DocumentAttribute>.FromString(data.Id);

        Metadata<Front> frontMetadata = MetadataConverterFrom<Front>.From(data.FrontMetadata);

        DocumentAttributeApprovalData approvalData = DocumentAttributeApprovalDataInternalConverter.ToDomain(data.ApprovalData);

        DocumentAttributePermission[] permissions = data.Permissions.Select(DocumentAttributePermissionInternalConverter.ToDomain).ToArray();

        SystemName? systemName = string.IsNullOrWhiteSpace(data.SystemName)
            ? null
            : SystemName.Parse(data.SystemName);
        DocumentAttributeData result = DocumentAttributeDataFactory.CreateFrom(
            id,
            data.IsArray,
            frontMetadata,
            approvalData,
            permissions,
            data.DocumentsRoles,
            data.RegistryRoles,
            data.LinkKind,
            systemName,
            data.DisplayName);

        return result;
    }
}
