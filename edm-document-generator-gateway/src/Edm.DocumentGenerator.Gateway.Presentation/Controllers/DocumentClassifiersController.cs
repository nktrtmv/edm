using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetBusinessSegments;
using Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetBusinessSegments.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentCategories;
using Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentCategories.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentKinds;
using Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentKinds.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentTypes;
using Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentTypes.Contracts;

namespace Edm.DocumentGenerator.Gateway.Presentation.Controllers;

[Route("document-classifiers")]
[ApiController]
[Authorize]
public class DocumentClassifiersController : ControllerBase
{
    private readonly GetBusinessSegmentsService _getBusinessSegmentsService;
    private readonly GetDocumentCategoriesService _getDocumentCategoriesService;
    private readonly GetDocumentKindsService _getDocumentKindsService;
    private readonly GetDocumentTypesService _getDocumentTypesService;

    public DocumentClassifiersController(
        GetBusinessSegmentsService getBusinessSegmentsService,
        GetDocumentCategoriesService getDocumentCategoriesService,
        GetDocumentTypesService getDocumentTypesService,
        GetDocumentKindsService getDocumentKindsService)
    {
        _getBusinessSegmentsService = getBusinessSegmentsService;
        _getDocumentCategoriesService = getDocumentCategoriesService;
        _getDocumentTypesService = getDocumentTypesService;
        _getDocumentKindsService = getDocumentKindsService;
    }

    [HttpPost(nameof(GetBusinessSegments), Name = nameof(GetBusinessSegments))]
    public async Task<GetBusinessSegmentsQueryBffResponse> GetBusinessSegments(GetBusinessSegmentsQueryBff query, CancellationToken cancellationToken)
    {
        var response = await _getBusinessSegmentsService.Get(query, cancellationToken);

        return response;
    }

    [HttpPost(nameof(GetDocumentCategories), Name = nameof(GetDocumentCategories))]
    public async Task<GetDocumentCategoriesQueryBffResponse> GetDocumentCategories(GetDocumentCategoriesQueryBff query, CancellationToken cancellationToken)
    {
        var response = await _getDocumentCategoriesService.Get(query, cancellationToken);

        return response;
    }

    [HttpPost(nameof(GetDocumentTypes), Name = nameof(GetDocumentTypes))]
    public async Task<GetDocumentTypesQueryBffResponse> GetDocumentTypes(GetDocumentTypesQueryBff query, CancellationToken cancellationToken)
    {
        var response = await _getDocumentTypesService.Get(query, cancellationToken);

        return response;
    }

    [HttpPost(nameof(GetDocumentKinds), Name = nameof(GetDocumentKinds))]
    public async Task<GetDocumentKindsQueryBffResponse> GetDocumentKinds(GetDocumentKindsQueryBff query, CancellationToken cancellationToken)
    {
        var response = await _getDocumentKindsService.Get(query, cancellationToken);

        return response;
    }
}
