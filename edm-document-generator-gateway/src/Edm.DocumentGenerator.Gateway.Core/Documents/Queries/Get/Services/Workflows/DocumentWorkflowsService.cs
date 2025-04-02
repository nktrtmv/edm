using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.Workflows.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.Workflows.Fetchers.Approval;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.Workflows.Fetchers.Signing;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.Workflows;

public sealed class DocumentWorkflowsService
{
    public DocumentWorkflowsService(
        ApprovalWorkflowDocumentWorkflowsFetcher approval,
        SigningWorkflowDocumentWorkflowsFetcher signing)
    {
        Approval = approval;
        Signing = signing;
    }

    private ApprovalWorkflowDocumentWorkflowsFetcher Approval { get; }
    private SigningWorkflowDocumentWorkflowsFetcher Signing { get; }

    internal async Task<DocumentWorkflows> Get(DocumentDetailedDto document, CancellationToken cancellationToken)
    {
        var approval = await Approval.Get(document, cancellationToken);

        var signing = await Signing.Get(document, cancellationToken);

        var result = new DocumentWorkflows(approval, signing);

        return result;
    }
}
