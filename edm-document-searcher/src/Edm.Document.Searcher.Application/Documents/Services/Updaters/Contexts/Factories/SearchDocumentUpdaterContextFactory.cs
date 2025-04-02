using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Fetchers.Approval;
using Edm.Document.Searcher.Domain.Documents;
using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles;
using Edm.Document.Searcher.ExternalServices.Documents;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.ApprovalData.Workflows;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.ApprovalData.Workflows.Statuses;
using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details;
using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows;
using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;
using Edm.Document.Searcher.GenericSubdomain;

using Microsoft.Extensions.Logging;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.Contexts.Factories;

internal sealed class SearchDocumentUpdaterContextFactory(
    ILogger<SearchDocumentUpdaterContextFactory> logger,
    IDocumentsClient documents,
    IDocumentsRegistryRolesClient registryRoles,
    ApprovalWorkflowDocumentWorkflowsFetcher workflowsFetcher,
    ISigningWorkflowsDetailsClient signingWorkflowsClient)
{
    private static readonly DateTimeOffset SupportMigrationTime =
        new DateTimeOffset(2024, 11, 19, 15, 0, 0, TimeSpan.FromHours(3));

    internal async Task<SearchDocumentUpdaterContext> Create(
        Id<SearchDocument> documentId,
        SearchDocument? originalDocument,
        CancellationToken cancellationToken)
    {
        DocumentExternal document = await GetDocument(documentId, cancellationToken);

        EntitiesApprovalWorkflowExternal[] approvalWorkflows;

        if (document.DomainId == "7496db8c-c80f-42ec-b724-f1590c458258" && document.Audit.CreatedDate.Value < SupportMigrationTime)
        {
            try
            {
                approvalWorkflows = await workflowsFetcher.Get(document, cancellationToken);
            }
            catch (Exception e) when (e.Message.Contains("is not found", StringComparison.InvariantCultureIgnoreCase))
            {
                logger.LogWarning("For document with id  {id} approval workflow is not found. Set to empty array", documentId.Value);
                approvalWorkflows = [];
            }
        }
        else
        {
            approvalWorkflows = await workflowsFetcher.Get(document, cancellationToken);
        }

        EntitiesApprovalWorkflowExternal? currentApprovalWorkflow = GetCurrentApprovalWorkflow(document, approvalWorkflows);

        SigningWorkflowExternal[] signingWorkflows = await GetSigningWorkflows(document, cancellationToken);

        DomainId domainId = DomainId.Parse(document.DomainId);
        Dictionary<int, SearchDocumentRegistryRoleInternal> registryRolesById = await GetRegistryRoles(domainId, cancellationToken);

        var result = new SearchDocumentUpdaterContext(
            document,
            approvalWorkflows,
            currentApprovalWorkflow,
            signingWorkflows,
            registryRolesById,
            originalDocument);

        return result;
    }

    private async Task<DocumentExternal> GetDocument(
        Id<SearchDocument> documentId,
        CancellationToken cancellationToken)
    {
        Id<DocumentExternal> entityId = IdConverterFrom<DocumentExternal>.From(documentId);

        DocumentExternal result = await documents.Get(entityId, cancellationToken);

        return result;
    }

    private async Task<Dictionary<int, SearchDocumentRegistryRoleInternal>> GetRegistryRoles(
        DomainId domainId,
        CancellationToken cancellationToken)
    {
        DocumentRegistryRoleExternal[] response = await registryRoles.Get(domainId, cancellationToken);

        SearchDocumentRegistryRoleInternal[] roles =
            response.Select(SearchDocumentRegistryRoleInternalConverter.FromExternal).ToArray();

        Dictionary<int, SearchDocumentRegistryRoleInternal> result =
            roles.ToDictionary(r => r.Id);

        return result;
    }

    private EntitiesApprovalWorkflowExternal? GetCurrentApprovalWorkflow(DocumentExternal document, EntitiesApprovalWorkflowExternal[] approvalWorkflows)
    {
        DocumentApprovalWorkflowExternal? approvalWorkflowData = document.ApprovalData.Workflows.LastOrDefault();

        if (approvalWorkflowData?.Status is not DocumentApprovalWorkflowStatusExternal.InProgress)
        {
            return null;
        }

        Id<EntitiesApprovalWorkflowExternal> approvalWorkflowId = IdConverterFrom<EntitiesApprovalWorkflowExternal>.From(approvalWorkflowData.Id);

        EntitiesApprovalWorkflowExternal? result = approvalWorkflows.FirstOrDefault(w => w.Id == approvalWorkflowId);

        return result;
    }

    private async Task<SigningWorkflowExternal[]> GetSigningWorkflows(DocumentExternal document, CancellationToken cancellationToken)
    {
        string[] ids = document.SigningData.Workflows.Select(w => w.Id.ToString()).ToArray();

        GetWorkflowsSigningWorkflowDetailsQueryResponseExternal response = await signingWorkflowsClient.GetWorkflows(ids, cancellationToken);

        return response.Workflows;
    }
}
