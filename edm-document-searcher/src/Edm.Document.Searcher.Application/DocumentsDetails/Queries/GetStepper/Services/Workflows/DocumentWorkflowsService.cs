using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Workflows;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Fetchers.Approval;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Fetchers.Signing;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts;
using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Workflows;

internal sealed class DocumentWorkflowsService(
    ApprovalWorkflowDocumentWorkflowsFetcher approvalFetcher,
    SigningWorkflowDocumentWorkflowsFetcher signingFetcher)
{
    internal async Task<DocumentWorkflows> Get(DocumentExternal document, CancellationToken cancellationToken)
    {
        EntitiesApprovalWorkflowExternal[] approval = await approvalFetcher.Get(document, cancellationToken);

        SigningWorkflowExternal[] signing = await signingFetcher.Get(document, cancellationToken);

        var result = new DocumentWorkflows(approval, signing);

        return result;
    }
}
