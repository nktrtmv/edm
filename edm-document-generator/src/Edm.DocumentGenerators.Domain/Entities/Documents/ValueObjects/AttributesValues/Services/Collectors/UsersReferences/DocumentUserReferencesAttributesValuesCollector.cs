using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Constants;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Services.Collectors.UsersReferences;

public static class DocumentUserReferencesAttributesValuesCollector
{
    public static IEnumerable<ReferenceDocumentAttributeValue> GetAll(DocumentAttributeValue[] attributesValues)
    {
        IEnumerable<ReferenceDocumentAttributeValue> result = DocumentAttributesValuesCollector.Collect(attributesValues)
            .OfType<ReferenceDocumentAttributeValue>()
            .Where(p => IsUserReference(p.Attribute));

        return result;
    }

    private static bool IsUserReference(DocumentAttribute attribute)
    {
        if (attribute is not DocumentReferenceAttribute referenceAttribute)
        {
            throw new UnsupportedTypeArgumentException<DocumentReferenceAttribute>(attribute);
        }

        bool result = referenceAttribute.ReferenceType.IsEqualTo(DocumentAttributeReferenceTypes.Employees);

        return result;
    }
}
