using JetBrains.Annotations;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Details.Queries.GetDelegateDetails.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Statuses;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Details.Queries.GetDelegateDetails;

[UsedImplicitly]
public sealed class GetDelegateDetailsDocumentWorkflowApprovalDetailsService
{
    public GetDelegateDetailsDocumentWorkflowApprovalDetailsService(IEntitiesApprovalWorkflowsDetailsClient details, ReferencesEnricher enricher)
    {
        Details = details;
        Enricher = enricher;
    }

    private IEntitiesApprovalWorkflowsDetailsClient Details { get; }
    private ReferencesEnricher Enricher { get; }

    public async Task<GetDelegateDetailsDocumentWorkflowApprovalDetailsQueryBffResponse> Get(
        GetDelegateDetailsDocumentWorkflowApprovalDetailsQueryBff query,
        UserBff user,
        CancellationToken cancellationToken)
    {
        var workflow = await GetWorkflow(query.Context.WorkflowId, cancellationToken);

        var stage = workflow.Stages.Single(s => s.Id == query.Context.StageId);

        if (stage.IsCompleted)
        {
            throw new ApplicationException($"Stage is completed.\nId: {stage.Id}");
        }

        var lastOwnerId = workflow.OwnersIds.LastOrDefault();

        var isOwner = lastOwnerId == user.Id;

        string[] delegateFromExecutorsIds = isOwner || user.IsAdmin
            ? GetActiveParticipantsIds(stage)
            : GetDelegateForParticipant(stage, user);

        var result =
            GetDelegateDetailsDocumentWorkflowApprovalDetailsQueryBffResponseConverter.ToBff(delegateFromExecutorsIds, Enricher);

        await Enricher.Enrich(cancellationToken);

        return result;
    }

    private async Task<EntitiesApprovalWorkflowExternal> GetWorkflow(string workflowId, CancellationToken cancellationToken)
    {
        string[] ids = { workflowId };

        var request = new GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryExternal(ids);

        EntitiesApprovalWorkflowExternal[] response = await Details.GetWorkflows(request, cancellationToken);

        var result = response.Single();

        return result;
    }

    private static string[] GetDelegateForParticipant(EntitiesApprovalWorkflowStageExternal stage, UserBff user)
    {
        string[] activeParticipantsIds = GetActiveParticipantsIds(stage);

        var hasUserActiveParticipants = activeParticipantsIds.Contains(user.Id);

        string[] result = hasUserActiveParticipants
            ? new[] { user.Id }
            : Array.Empty<string>();

        return result;
    }

    private static string[] GetActiveParticipantsIds(EntitiesApprovalWorkflowStageExternal stage)
    {
        string[] result = stage.Groups
            .Where(g => g.Status is EntitiesApprovalWorkflowGroupStatusExternal.InProgress)
            .SelectMany(a => a.Assignments)
            .Where(a => !a.IsCompleted)
            .Select(a => a.ExecutorId)
            .Distinct()
            .ToArray();

        return result;
    }
}
