using Edm.DocumentGenerators.Domain.Entities.Documents.Factories.CreationContext;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Constants;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.DocumentsRoles;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Custom.Authors;

internal sealed class AuthorDocumentAttributeValueFactory : IDocumentAttributeValueFactory
{
    DocumentAttributeValue? IDocumentAttributeValueFactory.CreateFrom(DocumentAttribute attribute, DocumentCreationContext context)
    {
        DocumentReferenceAttribute? authorAttribute = AsAuthorAttribute(attribute);

        if (authorAttribute is null)
        {
            return null;
        }

        var currentUserId = IdConverterTo.ToString(context.CurrentUserId);

        DocumentAttributeValue result = Create(authorAttribute, currentUserId);

        return result;
    }

    private static DocumentReferenceAttribute? AsAuthorAttribute(DocumentAttribute attribute)
    {
        if (attribute is not DocumentReferenceAttribute result)
        {
            return null;
        }

        if (!result.ReferenceType.IsEqualTo(DocumentAttributeReferenceTypes.Employees))
        {
            return null;
        }

        if (!result.Data.DocumentsRoles.Contains((int)DocumentAttributeDocumentRole.DocumentAuthor))
        {
            return null;
        }

        return result;
    }

    private static DocumentAttributeValue Create(DocumentReferenceAttribute attribute, string currentUserId)
    {
        var result = new ReferenceDocumentAttributeValue(attribute, new[] { currentUserId });

        return result;
    }
}
