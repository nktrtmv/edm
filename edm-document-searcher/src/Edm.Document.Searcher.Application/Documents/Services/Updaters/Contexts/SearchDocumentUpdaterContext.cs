using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;
using Edm.Document.Searcher.Domain.Documents;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts;
using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.Contexts;

internal sealed record SearchDocumentUpdaterContext(
    DocumentExternal Document,
    EntitiesApprovalWorkflowExternal[] ApprovalWorkflows,
    EntitiesApprovalWorkflowExternal? CurrentApprovalWorkflow,
    SigningWorkflowExternal[] SigningWorkflows,
    Dictionary<int, SearchDocumentRegistryRoleInternal> RegistryRolesById,
    SearchDocument? OriginalDocument);
