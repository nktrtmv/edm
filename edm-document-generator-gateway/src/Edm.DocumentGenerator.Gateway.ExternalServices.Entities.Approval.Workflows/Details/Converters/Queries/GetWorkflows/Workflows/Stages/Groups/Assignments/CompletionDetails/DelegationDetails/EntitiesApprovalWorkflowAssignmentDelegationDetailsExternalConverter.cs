using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.
    CompletionDetails.DelegationDetails.AutoDelegationKinds;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.
    CompletionDetails.DelegationDetails;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.
    CompletionDetails.DelegationDetails.AutoDelegationKinds;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.CompletionDetails.DelegationDetails;

internal static class EntitiesApprovalWorkflowAssignmentDelegationDetailsExternalConverter
{
    internal static EntitiesApprovalWorkflowAssignmentDelegationDetailsExternal FromDto(EntitiesApprovalWorkflowAssignmentDelegationDetailsDto details)
    {
        Id<EntitiesApprovalWorkflowAssignmentExternal> delegatedToId =
            IdConverterFrom<EntitiesApprovalWorkflowAssignmentExternal>.FromString(details.DelegatedToId);

        EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternal? autoDelegationKind = details.HasAutoDelegationKind
            ? EntitiesApprovalWorkflowAssignmentAutoDelegationKindExternalConverter.FromDto(details.AutoDelegationKind)
            : null;

        var result = new EntitiesApprovalWorkflowAssignmentDelegationDetailsExternal(delegatedToId, autoDelegationKind);

        return result;
    }
}
