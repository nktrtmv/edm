using Edm.DocumentGenerators.Application.Contracts.Attributes.Contracts.ApprovalData;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Contracts.Permissions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.LinksKinds;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions.Data;

public readonly record struct DocumentAttributeDataInternal(
    string Id,
    bool IsArray,
    Metadata<FrontInternal> FrontMetadata,
    DocumentAttributeApprovalDataInternal ApprovalData,
    DocumentAttributePermissionInternal[] Permissions,
    int[] DocumentsRoles,
    int[] RegistryRoles,
    DocumentLinkKind? LinkKind,
    string SystemName,
    string DisplayName);
