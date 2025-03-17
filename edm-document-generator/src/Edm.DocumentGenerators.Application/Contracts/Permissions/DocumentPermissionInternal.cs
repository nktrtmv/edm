using Edm.DocumentGenerators.Application.Contracts.Permissions.Types;

namespace Edm.DocumentGenerators.Application.Contracts.Permissions;

public sealed record DocumentPermissionInternal(DocumentPermissionTypeInternal Type, string[] RoleIds, string[] AttributeIds);
