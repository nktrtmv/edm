using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.ApprovalData;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.LinksKinds;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.Permissions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions.Data.Factories;

public static class DocumentAttributeDataFactory
{
    public static DocumentAttributeData CreateFrom(
        Id<DocumentAttribute> id,
        bool isArray,
        Metadata<Front> frontMetadata,
        DocumentAttributeApprovalData approvalData,
        DocumentAttributePermission[] permissions,
        int[] documentsRoles,
        int[] registryRoles,
        DocumentLinkKind? linkKind,
        SystemName? systemName,
        string displayName)
    {
        DocumentAttributeData result = CreateFromDb(
            id,
            isArray,
            frontMetadata,
            approvalData,
            permissions,
            documentsRoles,
            registryRoles,
            linkKind,
            systemName,
            displayName);

        return result;
    }

    public static DocumentAttributeData CreateFromDb(
        Id<DocumentAttribute> id,
        bool isArray,
        Metadata<Front> frontMetadata,
        DocumentAttributeApprovalData approvalData,
        DocumentAttributePermission[] permissions,
        int[] documentsRoles,
        int[] registryRoles,
        DocumentLinkKind? linkKind,
        SystemName? systemName,
        string displayName)
    {
        var result = new DocumentAttributeData(id, isArray, frontMetadata, approvalData, permissions, documentsRoles, registryRoles, linkKind, systemName, displayName);

        return result;
    }
}
