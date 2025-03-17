using Microsoft.Extensions.Logging;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.References;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.Tuples;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.
    References;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment.References;
using Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References;
using Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment.DocumentReferenceAuditAttributeValue;

internal sealed class DocumentReferenceAuditAttributeValueEnricher(ReferencesEnricher referenceEnricher, ILogger<DocumentDetailedBffEnricher> logger)
    : DocumentDelayedReferencesEnricherBase<DocumentReferenceAuditAttributeValueBff>(referenceEnricher, logger)
{
    protected override IEnumerable<ReferenceValueWithType> GetReferencesValuesWithTypes(
        IReadOnlyCollection<DocumentAttributeValueDetailedBff> attributeValues,
        string templateId,
        IReadOnlyCollection<DocumentReferenceAuditAttributeValueBff> values)
    {
        DocumentAttributeBff[] attributes = attributeValues.Select(a => a.Attribute).ToArray();

        DocumentReferenceAttributeBff[] referencesAttributes = SelectAllReferenceAttributes(attributes).ToArray();

        Dictionary<string, string> referenceTypeByAttributeId = referencesAttributes.ToDictionary(x => x.Id, x => x.ReferenceType);

        DocumentReferenceAuditAttributeValueBff[] existingValues = GetExistingValues(values, referenceTypeByAttributeId, this, Logger);

        foreach (var value in existingValues)
        {
            var key = new ReferenceTypeKey(referenceTypeByAttributeId[value.AttributeId], templateId, null);

            foreach (var reference in value.Value)
            {
                var result = new ReferenceValueWithType(key, reference);

                yield return result;
            }
        }
    }

    private static DocumentReferenceAuditAttributeValueBff[] GetExistingValues(
        IReadOnlyCollection<DocumentReferenceAuditAttributeValueBff> values,
        Dictionary<string, string> referenceTypeByAttributeId,
        DocumentReferenceAuditAttributeValueEnricher enricher,
        ILogger<DocumentDetailedBffEnricher> logger)
    {
        List<DocumentReferenceAuditAttributeValueBff> notFoundValues = values.Where(v => !referenceTypeByAttributeId.ContainsKey(v.AttributeId)).ToList();

        if (notFoundValues.Count != 0)
        {
            logger.LogError(
                "ERROR: ❌ Enricher ({@Enricher}). ValuesBff ({NotFoundValues}) was not found",
                enricher.ToString(),
                string.Join(", ", notFoundValues.Select(v => $"({v})")));
        }

        DocumentReferenceAuditAttributeValueBff[] result = values.Where(v => !notFoundValues.Contains(v)).ToArray();

        return result;
    }

    private static IEnumerable<DocumentReferenceAttributeBff> SelectAllReferenceAttributes(DocumentAttributeBff[] attributes)
    {
        foreach (var attribute in attributes)
        {
            switch (attribute)
            {
                case DocumentReferenceAttributeBff referenceAttribute:
                    yield return referenceAttribute;

                    break;

                case DocumentTupleAttributeBff tupleAttribute:

                    foreach (var innerReferenceAttribute in SelectAllReferenceAttributes(tupleAttribute.InnerAttributes))
                    {
                        yield return innerReferenceAttribute;
                    }

                    break;
            }
        }
    }

    public override string ToString()
    {
        return $"Enricher type: {GetType().Name}";
    }
}
