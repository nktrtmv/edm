using Edm.Document.Searcher.Presentation.Abstractions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Delete;

public sealed class DeleteDocumentsService(
    IWebHostEnvironment webHostEnvironment,
    IRoleAdapter roleAdapter,
    SearchDocumentsService.SearchDocumentsServiceClient searchDocumentsClient,
    IWorkflowsServiceClient workflowsServiceClient,
    DocumentGeneratorService documentGeneratorService)
{
    public async Task DeleteDocumentsByRoleValueContains(string domainId, string registryRole, string match, CancellationToken cancellationToken)
    {
        if (webHostEnvironment.IsProduction())
        {
            throw new ApplicationException("Only for non production qa documents");
        }

        var domainRoles = await roleAdapter.GetDomainRoles(domainId, cancellationToken);
        const int limit = 1000;
        var request = new SearchDocumentsQuery
        {
            Filters =
            {
                new SearchDocumentsQueryFilter
                {
                    Contains = new SearchDocumentsQueryContainsFilter
                    {
                        Values =
                        {
                            new SearchDocumentsQueryFilterValue
                            {
                                AsString = new SearchDocumentsQueryFilterStringValue
                                {
                                    Value = match
                                }
                            }
                        }
                    },
                    RegistryRolesIds =
                    {
                        domainRoles.GetRegistryRoleIdByName(registryRole)
                    }
                }
            },
            DomainId = domainId,
            Limit = limit,
            Skip = 0,
            SortParameters = new SearchDocumentsQuerySortParameters
            {
                SortOrder = SearchDocumentsQuerySortParametersSortOrder.Descending,
                RegistryRoleId = domainRoles.GetRegistryRoleIdByName("CreatedAt")
            }
        };

        while (!cancellationToken.IsCancellationRequested)
        {
            var response = await searchDocumentsClient.SearchAsync(request, cancellationToken: cancellationToken);
            var entitiesIds = response.DocumentsIds.ToArray();

            await documentGeneratorService.DeleteDocumentByIds(domainId, entitiesIds, cancellationToken);
            await workflowsServiceClient.DeleteWorkflowsByEntitiesIds(domainId, entitiesIds, cancellationToken);
            await searchDocumentsClient.DeleteAsync(
                new DeleteDocumentsCommand { DomainId = domainId, DocumentIds = { entitiesIds } },
                cancellationToken: cancellationToken);

            if (entitiesIds.Length < limit)
            {
                return;
            }
        }
    }
}
