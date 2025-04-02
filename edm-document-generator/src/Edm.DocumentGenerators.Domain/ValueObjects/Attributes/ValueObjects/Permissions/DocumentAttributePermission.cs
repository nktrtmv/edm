using Edm.DocumentGenerators.Domain.ValueObjects.Permissions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.Permissions;

public sealed class DocumentAttributePermission
{
    public DocumentAttributePermission(Id<DocumentStatus> status, DocumentPermission[] permissions)
    {
        Status = status;
        Permissions = permissions;
    }

    public Id<DocumentStatus> Status { get; }

    public DocumentPermission[] Permissions { get; }
}
