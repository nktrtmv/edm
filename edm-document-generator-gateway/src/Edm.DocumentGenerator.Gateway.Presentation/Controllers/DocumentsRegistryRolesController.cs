using Microsoft.AspNetCore.Mvc;

using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.DocumentsRoles.Queries.GetAll;
using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.DocumentsRoles.Queries.GetAll.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Queries.Get;
using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Queries.Get.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Queries.GetDocumentsAttributes;
using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Queries.GetDocumentsAttributes.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.GetAllDocumentsStatuses;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Contracts;

namespace Edm.DocumentGenerator.Gateway.Presentation.Controllers;

[Route("documents-roles")]
[ApiController]
public class DocumentsRegistryRolesController : ControllerBase
{
    public DocumentsRegistryRolesController(
        GetAllDocumentsAttributesRolesService getAllDocumentsAttributesRolesService,
        GetDocumentRegistryRolesService getDocumentRegistryRolesService,
        GetAllDocumentsAttributesDocumentRegistryRolesService getAllDocumentsAttributesDocumentRegistryRolesService,
        GetAllDocumentsStatusesDocumentTemplatesService documentsStatuses)
    {
        GetAllDocumentsAttributesRolesService = getAllDocumentsAttributesRolesService;
        GetDocumentRegistryRolesService = getDocumentRegistryRolesService;
        GetAllDocumentsAttributesDocumentRegistryRolesService = getAllDocumentsAttributesDocumentRegistryRolesService;
        DocumentsStatuses = documentsStatuses;
    }

    private GetAllDocumentsAttributesRolesService GetAllDocumentsAttributesRolesService { get; }
    private GetDocumentRegistryRolesService GetDocumentRegistryRolesService { get; }
    private GetAllDocumentsAttributesDocumentRegistryRolesService GetAllDocumentsAttributesDocumentRegistryRolesService { get; }
    private GetAllDocumentsStatusesDocumentTemplatesService DocumentsStatuses { get; }

    [HttpPost(nameof(GetAllDocumentsAttributesDocumentsRoles), Name = nameof(GetAllDocumentsAttributesDocumentsRoles))]
    public async Task<GetAllDocumentsAttributesDocumentsRolesQueryBffResponse> GetAllDocumentsAttributesDocumentsRoles(
        GetAllDocumentsAttributesDocumentsRolesQueryBff query,
        CancellationToken cancellationToken)
    {
        var response =
            await GetAllDocumentsAttributesRolesService.GetAllDocumentsAttributesDocumentsRoles(query, cancellationToken);

        return response;
    }

    [HttpPost(nameof(GetRegistryRoles), Name = nameof(GetRegistryRoles))]
    public async Task<GetDocumentRegistryRolesQueryBffResponse> GetRegistryRoles(GetDocumentRegistryRolesQueryBff request, CancellationToken cancellationToken)
    {
        var response = await GetDocumentRegistryRolesService.GetAll(request, cancellationToken);

        return response;
    }

    [HttpPost(nameof(GetAllDocumentsAttributesRegistryRoles), Name = nameof(GetAllDocumentsAttributesRegistryRoles))]
    public async Task<GetAllDocumentsAttributesDocumentRegistryRolesQueryBffResponse> GetAllDocumentsAttributesRegistryRoles(
        GetAllDocumentsAttributesDocumentRegistryRolesQueryBff queryBff,
        CancellationToken cancellationToken)
    {
        var response =
            await GetAllDocumentsAttributesDocumentRegistryRolesService.Get(queryBff, cancellationToken);

        return response;
    }

    [HttpPost(nameof(GetRegistryRolesStatusesSuggestions), Name = nameof(GetRegistryRolesStatusesSuggestions))]
    public async Task<ReferenceTypeValueBff[]> GetRegistryRolesStatusesSuggestions(
        GetRegistryRolesStatusesSuggestionsQueryBff queryBff,
        CancellationToken cancellationToken)
    {
        ReferenceTypeValueBff[] response = await DocumentsStatuses.Get(queryBff, cancellationToken);

        return response;
    }
}
