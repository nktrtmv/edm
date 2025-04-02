using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Details.Queries.GetAddParticipantDetails.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Details.Queries.GetAddParticipantDetails.Contracts.Contracts.Groups;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Statuses;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Details.Queries.GetAddParticipantDetails;

public sealed class GetAddParticipantDetailsDocumentWorkflowApprovalDetailsService
{
    public GetAddParticipantDetailsDocumentWorkflowApprovalDetailsService(IEntitiesApprovalWorkflowsDetailsClient details)
    {
        Details = details;
    }

    private IEntitiesApprovalWorkflowsDetailsClient Details { get; }

    public async Task<GetAddParticipantDetailsDocumentWorkflowApprovalDetailsQueryBffResponse> Get(
        GetAddParticipantDetailsDocumentWorkflowApprovalDetailsQueryBff query,
        CancellationToken cancellationToken)
    {
        var workflow = await GetWorkflow(query.Context.WorkflowId, cancellationToken);

        var stage = workflow.Stages.Single(s => s.Id == query.Context.StageId);

        if (stage.IsCompleted)
        {
            throw new ApplicationException($"Stage is completed.\nId: {stage.Id}");
        }

        EntitiesApprovalWorkflowGroupExternal[] inProgressGroups = stage.Groups
            .Where(g => g.Status is EntitiesApprovalWorkflowGroupStatusExternal.InProgress)
            .ToArray();

        GetAddParticipantDetailsDocumentWorkflowApprovalDetailsQueryBffResponseGroup[] groups =
            inProgressGroups.Select(GetAddParticipantDetailsDocumentWorkflowApprovalDetailsQueryBffResponseGroupConverter.FromExternal).ToArray();

        var result = new GetAddParticipantDetailsDocumentWorkflowApprovalDetailsQueryBffResponse
        {
            Groups = groups
        };

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
}
