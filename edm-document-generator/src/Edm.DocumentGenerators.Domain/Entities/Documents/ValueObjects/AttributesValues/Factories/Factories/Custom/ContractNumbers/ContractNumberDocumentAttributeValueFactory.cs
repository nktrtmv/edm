using Edm.DocumentGenerators.Domain.Entities.Documents.Factories.CreationContext;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Custom.ContractNumbers.Numberings;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.ValueObjects.Counters.Values;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.DocumentsRoles;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Custom.ContractNumbers;

public sealed class ContractNumberDocumentAttributeValueFactory : IDocumentAttributeValueFactory
{
    public DocumentAttributeValue? CreateFrom(DocumentAttribute attribute, DocumentCreationContext context)
    {
        DocumentStringAttribute? contractNumberAttribute = AsContractNumberAttribute(attribute);

        if (contractNumberAttribute is null)
        {
            return null;
        }

        DocumentAttributeValue result = Create(contractNumberAttribute, context.Template.DocumentPrototype.Numbering.Segments, context.CountersValues);

        return result;
    }

    private static DocumentStringAttribute? AsContractNumberAttribute(DocumentAttribute attribute)
    {
        if (attribute is not DocumentStringAttribute result)
        {
            return null;
        }

        if (!result.Data.DocumentsRoles.Contains((int)DocumentAttributeDocumentRole.DocumentRegistrationNumber))
        {
            return null;
        }

        return result;
    }

    private static DocumentAttributeValue Create(DocumentStringAttribute attribute, DocumentNumberingSegment[] segments, CounterValue[] countersValues)
    {
        string? number = DocumentNumberingFormatter.FormatNumber(segments, countersValues);

        string[] value = number is null
            ? []
            : [number];

        var result = new StringDocumentAttributeValue(attribute, value);

        return result;
    }
}
