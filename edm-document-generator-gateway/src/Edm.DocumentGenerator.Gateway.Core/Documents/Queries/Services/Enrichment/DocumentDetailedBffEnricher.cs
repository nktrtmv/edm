using Microsoft.Extensions.Logging;

using Edm.DocumentGenerator.Gateway.Core.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues.Inheritors.References;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.AttributeValuesChanged.Changes.AttributeValues.Inheritors.
    References;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment.DocumentAttributeValueReference;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment.DocumentReferenceAuditAttributeValue;
using Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;

public sealed class DocumentDetailedBffEnricher
{
    public DocumentDetailedBffEnricher(ReferencesEnricher references, ILogger<DocumentDetailedBffEnricher> logger)
    {
        References = references;
        ReferenceAttributes = new DocumentAttributeValueReferenceDetailedEnricher(References, logger);
        ReferenceAuditAttributes = new DocumentReferenceAuditAttributeValueEnricher(References, logger);
    }

    private DocumentAttributeValueReferenceDetailedEnricher ReferenceAttributes { get; }
    private DocumentReferenceAuditAttributeValueEnricher ReferenceAuditAttributes { get; }
    internal ReferencesEnricher References { get; }

    public void Add(PersonBff person)
    {
        References.Add(person);
    }

    public void Add(DocumentReferenceAttributeValueDetailedBff attribute)
    {
        ReferenceAttributes.Add(attribute);
    }

    public void Add(DocumentReferenceAuditAttributeValueBff attribute)
    {
        ReferenceAuditAttributes.Add(attribute);
    }

    public void DocumentConversionComplete(DocumentAttributeValueDetailedBff[] attributeValues, string templateId)
    {
        ReferenceAuditAttributes.DocumentConversionComplete(attributeValues, templateId);
        ReferenceAttributes.DocumentConversionComplete(attributeValues, templateId);
    }

    public async Task Enrich(CancellationToken cancellationToken)
    {
        await References.Enrich(cancellationToken);
        await ReferenceAuditAttributes.Enrich(cancellationToken);
    }
}
