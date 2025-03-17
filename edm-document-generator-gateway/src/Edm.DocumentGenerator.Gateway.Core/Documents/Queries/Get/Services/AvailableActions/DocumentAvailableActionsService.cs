using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions.Transitions;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions.Detectors.Approval;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions.Detectors.Signing;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions.Detectors.Transitions;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions.Fetchers.Approval;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions.Fetchers.Signing;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.Workflows.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions;

public sealed class DocumentAvailableActionsService
{
    public DocumentAvailableActionsService(
        ApprovalWorkflowAvailableActionsFetcher approval,
        SigningWorkflowAvailableActionsFetcher signing)
    {
        Approval = approval;
        Signing = signing;
    }

    private ApprovalWorkflowAvailableActionsFetcher Approval { get; }
    private SigningWorkflowAvailableActionsFetcher Signing { get; }

    internal async Task<DocumentWorkflowAvailableActionsBff> Get(
        DocumentWorkflows workflows,
        DocumentDetailedDto document,
        UserBff user,
        CancellationToken cancellationToken)
    {
        var availableActions = await Fetch(workflows, document, user, cancellationToken);

        var result = Detect(availableActions, document, user);

        return result;
    }

    private async Task<DocumentAvailableActions> Fetch(DocumentWorkflows workflows, DocumentDetailedDto document, UserBff user, CancellationToken cancellationToken)
    {
        var approval = await Approval.Fetch(workflows, document, user, cancellationToken);

        var signing = await Signing.Fetch(workflows, document, user, cancellationToken);

        var result = new DocumentAvailableActions(approval, signing);

        return result;
    }

    private static DocumentWorkflowAvailableActionsBff Detect(DocumentAvailableActions availableActions, DocumentDetailedDto document, UserBff user)
    {
        var approval = ApprovalWorkflowAvailableActionsDetector.Detect(availableActions);

        var signing = SigningWorkflowAvailableActionsDetector.Detect(availableActions, document);

        DocumentStatusTransitionDetailedBff[] transitions = StatusTransitionsAvailableActionsDetector.Detect(availableActions, document, user);

        var result = new DocumentWorkflowAvailableActionsBff(approval, signing, transitions);

        return result;
    }
}
