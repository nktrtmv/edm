using System.Text.Json.Serialization;

using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.ApprovalData;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.LinksKinds;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.Permissions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions.Data;

public sealed class DocumentAttributeData
{
    internal static readonly DocumentAttributeData Empty =
        new DocumentAttributeData(
            Id<DocumentAttribute>.Empty,
            false,
            Metadata<Front>.Empty,
            DocumentAttributeApprovalData.Empty,
            [],
            [],
            [],
            null,
            null,
            string.Empty);

    internal DocumentAttributeData(
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
        Id = id;
        IsArray = isArray;
        FrontMetadata = frontMetadata;
        ApprovalData = approvalData;
        Permissions = permissions;
        DocumentsRoles = documentsRoles;
        RegistryRoles = registryRoles;
        LinkKind = linkKind;
        SystemName = systemName;
        DisplayName = displayName;
    }

    public Id<DocumentAttribute> Id { get; }
    public bool IsArray { get; }
    public Metadata<Front> FrontMetadata { get; }
    public DocumentAttributeApprovalData ApprovalData { get; private set; }

    [JsonIgnore]
    public DocumentAttributePermission[] Permissions { get; }

    public int[] DocumentsRoles { get; private set; }
    public int[] RegistryRoles { get; private set; }
    public DocumentLinkKind? LinkKind { get; }

    public SystemName? SystemName { get; private set; }
    public string DisplayName { get; }

    public void SetApprovalData(DocumentAttributeApprovalData approvalData)
    {
        ApprovalData = approvalData;
    }

    public void SetDocumentsRoles(int[] roles) // TODO: REMOVE: This is for backward compatability
    {
        DocumentsRoles = roles;
    }

    public void SetRegistryRoles(int[] roles) // TODO: REMOVE: This is for backward compatability
    {
        RegistryRoles = roles;
    }

    public void SetSystemName(SystemName? systemName)
    {
        SystemName = systemName;
    }
}
