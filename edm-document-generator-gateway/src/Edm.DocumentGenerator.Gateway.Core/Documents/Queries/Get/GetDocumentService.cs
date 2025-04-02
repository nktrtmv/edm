using Edm.DocumentGenerators.Presentation.Abstractions;

using Microsoft.Extensions.DependencyInjection;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Classifications;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.Collectors;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.StepperDetails;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.Workflows;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment.Contexts;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Enrichers.Abstractions.Sources;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get;

public sealed class GetDocumentService(
    DocumentsService.DocumentsServiceClient documentsServiceClient,
    DocumentWorkflowsService workflowsService,
    DocumentAvailableActionsService availableActionsService,
    IEnumerable<IEnricherSource> enricherSources,
    IRoleAdapter roleAdapter,
    IServiceProvider serviceProvider)
{
    public async Task<bool> CheckDocumentHasEditRole(string domainId, string documentId, UserBff user, string roleId, CancellationToken cancellationToken)
    {
        var request = new GetDocumentQueryBff
        {
            Id = documentId,
            DomainId = domainId,
            SkipProcessing = true
        };

        var response = await GetDocumentResponse(request, cancellationToken);

        var editPermissions = response.Document.AttributesValues
            .SelectMany(x => x.Attribute.Data.Permissions)
            .SelectMany(x => x.Permissions)
            .Where(x => x.Type is DocumentPermissionTypeDto.Edit)
            .ToArray();

        HashSet<string> editRoles = editPermissions.SelectMany(x => x.RoleIds).ToHashSet();

        HashSet<string> editAttributeIds = editPermissions.SelectMany(x => x.AttributeIds).ToHashSet();

        HashSet<string> editAttributeValues = response.Document.AttributesValues
            .Where(x => editAttributeIds.Contains(x.Attribute.Data.Id))
            .SelectMany(x => x.AsReference.Values)
            .ToHashSet();

        var result = editRoles.Contains(roleId) || editAttributeValues.Contains(user.Id);

        return result;
    }

    public async Task<GetDocumentQueryBffResponse> GetEnriched(GetDocumentQueryBff request, UserBff user, CancellationToken cancellationToken)
    {
        var roles = await roleAdapter.GetDomainRoles(request.DomainId, cancellationToken);
        var response = await GetDocumentResponse(request, cancellationToken);

        var workflows = await workflowsService.Get(response.Document, cancellationToken);

        var availableActions = await availableActionsService.Get(workflows, response.Document, user, cancellationToken);

        var documentEnricherContext = new DocumentEnricherContext(response.Document, user, workflows);

        Dictionary<string, string> attributesFrontMetadata = DocumentAttributesFrontMetadataCollector.Collect(response.Document);

        var enricher = serviceProvider.GetRequiredService<DocumentDetailedBffEnricher>(); // TODO: Rewrite from transient
        var documentConversionContext = new DocumentConversionContext(enricher, attributesFrontMetadata, documentEnricherContext);

        var stepperDetails = DocumentWorkflowStepperDetailsConstructor.Construct(
            response.Document,
            workflows,
            documentConversionContext);

        var documentClassification = response.Document.Classification;
        var classification = documentClassification == null
            ? null
            : new DocumentClassificationBff(
                documentClassification.BusinessSegment,
                documentClassification.Category,
                documentClassification.Type,
                documentClassification.Kind);

        var attributesToBuildLinks = response.Document.AttributesValues
            .Where(x => x.Attribute.Data.LinkKind is DocumentLinkKindDto.Master or DocumentLinkKindDto.External)
            .ToList();

        var document = DocumentDetailedBffConverter.ToBff(
            response.Document,
            classification,
            availableActions,
            stepperDetails,
            documentConversionContext,
            roles);

        await enricher.Enrich(cancellationToken);

        await documentEnricherContext.Enrich(enricherSources, cancellationToken);

        var result = GetDocumentQueryBffResponseConverter.FromInternal(document);

        return result;
    }

    private async Task<GetDocumentQueryResponse> GetDocumentResponse(GetDocumentQueryBff documentQueryBff, CancellationToken cancellationToken)
    {
        var query = GetDocumentQueryBffConverter.ToDto(documentQueryBff);
        var response = await documentsServiceClient.GetAsync(query, cancellationToken: cancellationToken);

        if (response.Document == null)
        {
            throw new ApplicationException($"Document (id: {query.DocumentId}) is not found.");
        }

        return response;
    }
}
