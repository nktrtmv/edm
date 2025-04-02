using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.DocumentsRoles.Contracts.Types;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.DocumentsRoles.Contracts;

public sealed class DocumentsAttributesDocumentsRolesBff
{
    public required DocumentAttributeTypeBff AttributeType { get; set; }
    public required DocumentAttributeDocumentRoleBff[] Roles { get; set; }
}
