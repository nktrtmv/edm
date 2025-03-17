using System.Text.Json.Serialization;

using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts.Contracts.Documents.AttributesValues.Inheritors.Inheritors;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Services.Enrichment.References;
using Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Services.Enrichment;

public sealed class GetAllDocumentsQueryResponseDocumentBffEnricher
{
    public GetAllDocumentsQueryResponseDocumentBffEnricher(ReferencesEnricher references)
    {
        References = references;
        ReferenceAttributes = new SearchDocumentDelayedReferencesEnricher(References);
    }

    [JsonInclude]
    private ReferencesEnricher References { get; }

    [JsonInclude]
    private SearchDocumentDelayedReferencesEnricher ReferenceAttributes { get; }

    public void Add(GetAllDocumentsQueryResponseDocumentReferenceAttributeValueBff attributeValue)
    {
        ReferenceAttributes.Add(attributeValue);
    }

    public async Task Enrich(CancellationToken cancellationToken)
    {
        await References.Enrich(cancellationToken);
    }

    public void DocumentConversionComplete(string templateId, DocumentRegistryRoleExternal[] registryRoles)
    {
        ReferenceAttributes.DocumentConversionComplete(templateId, registryRoles);
    }
}
