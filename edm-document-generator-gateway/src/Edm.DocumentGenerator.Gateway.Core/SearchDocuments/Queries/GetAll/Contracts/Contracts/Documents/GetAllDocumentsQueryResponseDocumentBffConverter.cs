using Edm.Document.Searcher.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts.Contracts.Documents.AttributesValues;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Services.Enrichment.Context;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts.Contracts.Documents;

internal static class GetAllDocumentsQueryResponseDocumentBffConverter
{
    internal static GetAllDocumentsQueryResponseDocumentBff FromDto(
        GetDocumentsQueryResponseSearchDocument document,
        DocumentRegistryRoleExternal[] registryRoles,
        GetAllDocumentsQueryResponseDocumentBffContext conversionContext,
        DomainRoles domainRoles)
    {
        GetAllDocumentsQueryResponseDocumentAttributeValueBff[] attributesValues = document.AttributesValues
            .Select(v => GetAllDocumentsQueryResponseDocumentAttributeValueBffConverter.FromDto(v, conversionContext, domainRoles))
            .ToArray();

        var result = new GetAllDocumentsQueryResponseDocumentBff
        {
            Id = document.Id,
            AttributesValues = attributesValues
        };

        conversionContext.Enricher.DocumentConversionComplete(document.TemplateId, registryRoles);

        return result;
    }
}
