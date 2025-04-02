using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.ValueObjects.AttributesChanges;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.DocumentsRoles;

namespace Edm.DocumentGenerators.Application.Documents.Commands.UpdateBatch.DocumentClerk.Contracts;

internal static class DocumentClerkBatchUpdateCommandInternalConverter
{
    public static DocumentUpdateParameters ToDomain(Document document, string newClerkAttributeValue)
    {
        IEnumerable<DocumentAttributeValue> attributes = ToDomainUpdatedAttributeValues(document.AttributesValues, newClerkAttributeValue);

        var attributesChange = new DocumentAttributesChange(document.AttributesValues, attributes.ToArray());

        DocumentUpdateParameters result = DocumentUpdateParametersFactory.Create(null, attributesChange);

        return result;
    }

    private static IEnumerable<DocumentAttributeValue> ToDomainUpdatedAttributeValues(DocumentAttributeValue[] originalAttributesValues, string newClerkAttributeValue)
    {
        foreach (DocumentAttributeValue originalAttributesValue in originalAttributesValues)
        {
            if (
                originalAttributesValue.Attribute.Data.DocumentsRoles.Contains((int)DocumentAttributeDocumentRole.DocumentClerk) &&
                originalAttributesValue is ReferenceDocumentAttributeValue)
            {
                var result = new ReferenceDocumentAttributeValue(originalAttributesValue.Attribute, [newClerkAttributeValue]);

                yield return result;
            }
            else
            {
                yield return originalAttributesValue;
            }
        }
    }
}
