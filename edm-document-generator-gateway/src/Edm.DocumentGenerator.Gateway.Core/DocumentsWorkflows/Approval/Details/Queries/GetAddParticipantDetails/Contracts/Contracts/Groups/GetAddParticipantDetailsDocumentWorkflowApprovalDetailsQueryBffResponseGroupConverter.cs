using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Details.Queries.GetAddParticipantDetails.Contracts.Contracts.Groups;

internal static class GetAddParticipantDetailsDocumentWorkflowApprovalDetailsQueryBffResponseGroupConverter
{
    internal static GetAddParticipantDetailsDocumentWorkflowApprovalDetailsQueryBffResponseGroup FromExternal(EntitiesApprovalWorkflowGroupExternal group)
    {
        var result = new GetAddParticipantDetailsDocumentWorkflowApprovalDetailsQueryBffResponseGroup
        {
            Id = group.Id,
            Name = group.Name
        };

        return result;
    }
}
