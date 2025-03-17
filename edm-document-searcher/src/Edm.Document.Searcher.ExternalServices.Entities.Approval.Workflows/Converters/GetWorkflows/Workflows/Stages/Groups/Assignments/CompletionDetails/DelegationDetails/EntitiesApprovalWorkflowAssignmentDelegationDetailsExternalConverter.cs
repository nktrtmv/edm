using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Assignments;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Assignments.CompletionDetails.DelegationDetails;
using Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows.Stages.Groups.Assignments.CompletionDetails.DelegationDetails.AutoDelegationKinds;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows.Stages.Groups.Assignments.CompletionDetails.DelegationDetails;

public static class EntitiesApprovalWorkflowAssignmentDelegationDetailsExternalConverter
{
    public static EntitiesApprovalWorkflowAssignmentDelegationDetailsExternal? FromDto(EntitiesApprovalWorkflowAssignmentDelegationDetailsDto? delegationDetails)
    {
        if (delegationDetails is null)
        {
            return null;
        }

        Id<EntitiesApprovalWorkflowAssignmentExternal> delegatedToId = IdConverterFrom<EntitiesApprovalWorkflowAssignmentExternal>.FromString(delegationDetails.DelegatedToId);
        var kind = EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternalConverter.FromDto(delegationDetails);

        var result = new EntitiesApprovalWorkflowAssignmentDelegationDetailsExternal(delegatedToId, kind);

        return result;
    }
}
