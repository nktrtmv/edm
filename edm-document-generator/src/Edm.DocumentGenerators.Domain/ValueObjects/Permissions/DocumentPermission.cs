using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Permissions.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Permissions.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Permissions;

public sealed record DocumentPermission(DocumentPermissionType Type, Id<DocumentRole>[] RoleIds, Id<DocumentAttribute>[] AttributeIds);
