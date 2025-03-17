using Edm.Document.Classifier.Application.Contracts.Documents.Attributes.Types;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts;

namespace Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDocumentsAttributes.Contracts.DocumentsAttributes;

public sealed class DocumentAttributeDocumentRegistryRolesInternal
{
    internal DocumentAttributeDocumentRegistryRolesInternal(DocumentAttributeTypeInternal attribute, DomainRegistryRoleInternal[] roles)
    {
        Attribute = attribute;
        Roles = roles;
    }

    public DocumentAttributeTypeInternal Attribute { get; }
    public DomainRegistryRoleInternal[] Roles { get; }
}
