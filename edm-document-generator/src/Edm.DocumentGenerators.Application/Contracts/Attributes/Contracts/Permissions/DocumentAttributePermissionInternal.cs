using Edm.DocumentGenerators.Application.Contracts.Permissions;

namespace Edm.DocumentGenerators.Application.Contracts.Attributes.Contracts.Permissions;

public sealed record DocumentAttributePermissionInternal(string StatusId, DocumentPermissionInternal[] Permissions);
