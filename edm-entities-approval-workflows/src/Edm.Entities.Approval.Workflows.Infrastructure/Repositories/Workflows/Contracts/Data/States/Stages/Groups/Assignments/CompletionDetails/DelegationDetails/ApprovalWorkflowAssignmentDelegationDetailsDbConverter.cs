using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.ValueObjects.DelegationDetails;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.ValueObjects.DelegationDetails.ValueObjects.AutoDelegationKinds;
using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.Assignments.CompletionDetails.DelegationDetails.
    AutoDelegationKinds;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.Assignments.CompletionDetails.DelegationDetails;

internal static class ApprovalWorkflowAssignmentDelegationDetailsDbConverter
{
    internal static ApprovalWorkflowAssignmentDelegationDetailsDb FromDomain(ApprovalWorkflowAssignmentDelegationDetails details)
    {
        var delegatedToId = IdConverterTo.ToString(details.DelegatedToId);

        var result = new ApprovalWorkflowAssignmentDelegationDetailsDb
        {
            DelegatedToId = delegatedToId
        };

        if (details.AutoDelegationKind is not null)
        {
            ApprovalWorkflowAssignmentAutoDelegationKindDb autoDelegationKind =
                ApprovalWorkflowAssignmentAutoDelegationKindDbConverter.FromDomain(details.AutoDelegationKind.Value);

            result.AutoDelegationKind = autoDelegationKind;
        }

        return result;
    }

    internal static ApprovalWorkflowAssignmentDelegationDetails ToDomain(ApprovalWorkflowAssignmentDelegationDetailsDb details)
    {
        Id<ApprovalWorkflowAssignment> delegatedToId =
            IdConverterFrom<ApprovalWorkflowAssignment>.FromString(details.DelegatedToId);

        ApprovalWorkflowAssignmentAutoDelegationKind? autoDelegationKind = details.HasAutoDelegationKind
            ? ApprovalWorkflowAssignmentAutoDelegationKindDbConverter.ToDomain(details.AutoDelegationKind)
            : null;

        var result = new ApprovalWorkflowAssignmentDelegationDetails(delegatedToId, autoDelegationKind);

        return result;
    }

    [Obsolete]
    internal static ApprovalWorkflowAssignmentDelegationDetails? ToDomainObsolete(ApprovalWorkflowAssignmentDb assigment, Dictionary<string, string> delegatedToIds)
    {
        string? delegatedToIdDb = delegatedToIds.GetValueOrDefault(assigment.Id);

        Id<ApprovalWorkflowAssignment>? delegatedToId =
            NullableConverter.Convert(delegatedToIdDb, IdConverterFrom<ApprovalWorkflowAssignment>.FromString);

        ApprovalWorkflowAssignmentDelegationDetails? result = string.IsNullOrWhiteSpace(delegatedToIdDb)
            ? null
            : new ApprovalWorkflowAssignmentDelegationDetails(delegatedToId!, null);

        return result;
    }
}
