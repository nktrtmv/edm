using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.CollectionQueryResponses;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.GetAll.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.GetAll.Contracts.Slim;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.GetAll.Contracts.Slim.Filters;
using Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.GetAll;

public sealed class GetAllDocumentTemplatesService(DocumentTemplateService.DocumentTemplateServiceClient serviceClient, ReferencesEnricher personsEnricher)
    : DocumentTemplateServiceClientBase(serviceClient)
{
    public async Task<GetAllDocumentTemplatesQueryBffResponse> GetAll(
        string domainId,
        int skip,
        int limit,
        DocumentsTemplatesFilteringParametersDto filteringParameters,
        CancellationToken cancellationToken)
    {
        List<DocumentTemplateSlimDto> items = [];
        var hasMoreTemplates = true;

        DocumentTemplateStatusDto? requestedStatus = !string.IsNullOrWhiteSpace(filteringParameters.Status)
            ? Enum.Parse<DocumentTemplateStatusDto>(filteringParameters.Status)
            : null;

        while (hasMoreTemplates && items.Count < limit)
        {
            var queryParams = new GetAllDocumentsTemplatesQueryParamsDto
            {
                Query = filteringParameters.Query,
                Limit = limit,
                Skip = skip
            };

            var query = new GetAllDocumentTemplatesQuery
            {
                QueryParams = queryParams,
                DomainId = domainId
            };

            var response = await DocumentTemplateServiceClient.GetAllAsync(query, cancellationToken: cancellationToken);
            skip += response.Templates.Count;
            hasMoreTemplates = response.Templates.Count == limit;

            if (requestedStatus is { } status)
            {
                List<DocumentTemplateSlimDto> filteredItems = response.Templates.Where(x => x.Status == status).ToList();
                var missingItemsCount = Math.Max(0, limit - items.Count);

                items.AddRange(filteredItems.Take(missingItemsCount));
            }
            else
            {
                items.AddRange(response.Templates);
            }
        }

        var templates = items.Select(t => DocumentTemplateSlimBffConverter.ToBff(domainId, t, personsEnricher)).ToArray();
        await personsEnricher.Enrich(cancellationToken);
        CollectionQueryResponse<DocumentTemplateSlimBff> collection = CollectionQueryResponseConverter.ToBff(templates);

        var result = new GetAllDocumentTemplatesQueryBffResponse
        {
            Templates = collection
        };

        return result;
    }
}
