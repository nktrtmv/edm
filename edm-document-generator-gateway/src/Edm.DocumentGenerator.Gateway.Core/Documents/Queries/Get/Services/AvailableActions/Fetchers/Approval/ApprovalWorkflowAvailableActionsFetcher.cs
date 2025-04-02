using Edm.DocumentGenerators.Presentation.Abstractions;

using Microsoft.Extensions.Logging;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions.Contracts.Approval;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.Workflows.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Queries.GetAvailable;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Queries.GetAvailable.Actions.Kinds;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions.Fetchers.Approval;

public sealed class ApprovalWorkflowAvailableActionsFetcher(ILogger<ApprovalWorkflowAvailableActionsFetcher> logger, IEntitiesApprovalWorkflowsActionsClient actions)
{
    private IEntitiesApprovalWorkflowsActionsClient Actions { get; } = actions;

    internal async Task<DocumentApprovalActions?> Fetch(
        DocumentWorkflows workflows,
        DocumentDetailedDto document,
        UserBff user,
        CancellationToken cancellationToken)
    {
        var workflowId = GetWorkflowId(document);

        if (workflowId is null)
        {
            return null;
        }

        var workflow = workflows.Approval.Single(w => w.Id == workflowId);

        var activeStage = workflow.Stages
            .FirstOrDefault(s => !s.IsCompleted);

        if (activeStage == null)
        {
            logger.LogError(
                "For document in domain {domainId} with id {documentId} workflow with id {workflowId} no active stage found",
                document.DomainId,
                document.Id,
                workflow.Id);

            return null;
        }

        var actions = await GetAvailableActions(workflow.Id, user, cancellationToken);

        var result = new DocumentApprovalActions(workflowId, activeStage.Id, actions, activeStage.Type);

        return result;
    }

    private static string? GetWorkflowId(DocumentDetailedDto document)
    {
        if (document.Status.Type != DocumentStatusTypeDto.Approval)
        {
            return null;
        }

        var workflow = document.ApprovalData?.Workflows?.LastOrDefault();

        if (workflow is null)
        {
            throw new ApplicationException($"Failed to find reduction workflow (documentId: {document.Id}.");
        }

        if (workflow.Status == DocumentApprovalWorkflowStatusDto.Finished)
        {
            throw new ApplicationException(
                $"Failed to find uncompleted reduction workflow (documentId: {document.Id}, workflowId: {workflow.Id}, status: {workflow.Status}).");
        }

        var result = workflow.Id;

        return result;
    }

    private async Task<EntitiesApprovalWorkflowActionKindExternal[]> GetAvailableActions(string workflowId, UserBff user, CancellationToken cancellationToken)
    {
        var request = new GetAvailableEntitiesApprovalWorkflowsActionsQueryExternal(workflowId, user.Id, user.IsAdmin);

        var response = await Actions.GetAvailableActions(request, cancellationToken);

        var result = response.Actions;

        return result;
    }
}
