using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions.Data;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions.Data.Factories;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.ApprovalData;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.LinksKinds;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.Permissions;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Attributes.Contracts.ApprovalData;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Attributes.Contracts.LinksKinds;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Attributes.Contracts.Permissions;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Attributes.Abstractions.Data;

internal static class DocumentAttributeDataDbConverter
{
    internal static DocumentAttributeDataDb FromDomain(DocumentAttributeData data)
    {
        var id = IdConverterTo.ToString(data.Id);

        var frontMetadata = MetadataConverterTo.ToString(data.FrontMetadata);

        DocumentAttributeApprovalDataDb approvalData = DocumentAttributeApprovalDataDbConverter.FromDomain(data.ApprovalData);

        DocumentAttributePermissionDb[] permissions = data.Permissions.Select(DocumentAttributePermissionDbConverter.FromDomain).ToArray();

        int[] registryRoles = data.RegistryRoles;

        DocumentLinkKindDb? linkKind = NullableConverter.Convert(data.LinkKind, DocumentLinkKindDbConverter.FromDomain);

        var result = new DocumentAttributeDataDb
        {
            Id = id,
            IsArray = data.IsArray,
            FrontMetadata = frontMetadata,
            ApprovalData = approvalData,
            Permissions = { permissions },
            DocumentsRoles = { data.DocumentsRoles },
            RegistryRoles = { registryRoles },
            SystemName = data.SystemName?.Value ?? "",
            DisplayName = data.DisplayName
        };

        if (linkKind != null)
        {
            result.LinkKind = linkKind.Value;
        }

        return result;
    }

    internal static DocumentAttributeData ToDomain(DocumentAttributeDataDb data)
    {
        Id<DocumentAttribute> id = IdConverterFrom<DocumentAttribute>.FromString(data.Id);

        Metadata<Front> frontMetadata = MetadataConverterFrom<Front>.FromString(data.FrontMetadata);

        DocumentAttributeApprovalData approvalData = DocumentAttributeApprovalDataDbConverter.ToDomain(data.ApprovalData);

        DocumentAttributePermission[] permissions = data.Permissions.Select(DocumentAttributePermissionDbConverter.ToDomain).ToArray();

        int[] registryRoles = data.RegistryRoles.ToArray();

        DocumentLinkKind? linkKind = data.HasLinkKind
            ? DocumentLinkKindDbConverter.ToDomain(data.LinkKind)
            : null;

        SystemName? systemName = string.IsNullOrWhiteSpace(data.SystemName)
            ? null
            : SystemName.Parse(data.SystemName);

        DocumentAttributeData result = DocumentAttributeDataFactory.CreateFromDb(
            id,
            data.IsArray,
            frontMetadata,
            approvalData,
            permissions,
            data.DocumentsRoles.ToArray(),
            registryRoles,
            linkKind,
            systemName,
            data.DisplayName);

        return result;
    }
}
