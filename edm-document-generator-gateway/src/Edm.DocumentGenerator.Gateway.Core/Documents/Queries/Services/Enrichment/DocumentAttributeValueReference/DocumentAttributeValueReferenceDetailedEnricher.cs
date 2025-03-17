using Microsoft.Extensions.Logging;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Inheritors.References;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues.Inheritors.References;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment.References;
using Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References;
using Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment.DocumentAttributeValueReference;

internal sealed class DocumentAttributeValueReferenceDetailedEnricher(ReferencesEnricher referenceEnricher, ILogger<DocumentDetailedBffEnricher> logger)
    : DocumentDelayedReferencesEnricherBase<DocumentReferenceAttributeValueDetailedBff>(referenceEnricher, logger)
{
    protected override IEnumerable<ReferenceValueWithType> GetReferencesValuesWithTypes(
        IReadOnlyCollection<DocumentAttributeValueDetailedBff> attributeValues,
        string templateId,
        IReadOnlyCollection<DocumentReferenceAttributeValueDetailedBff> values)
    {
        foreach (var x in values)
        {
            var referenceType = ((DocumentReferenceAttributeBff)x.Attribute).ReferenceType;

            foreach (var v in x.Values)
            {
                var key = new ReferenceTypeKey(referenceType, templateId, null);

                yield return new ReferenceValueWithType(key, v);
            }
        }
    }
}
