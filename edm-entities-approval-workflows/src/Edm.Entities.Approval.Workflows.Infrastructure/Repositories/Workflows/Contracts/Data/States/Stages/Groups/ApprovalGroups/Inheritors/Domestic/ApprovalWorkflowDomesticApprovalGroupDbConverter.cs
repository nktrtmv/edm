using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.
    Domestic;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.
    Domestic.ValueObjects.ApprovalParticipants;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.ApprovalGroups.Inheritors.Domestic.ApprovalParticipants;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.ApprovalGroups.Inheritors.Domestic;

internal static class ApprovalWorkflowDomesticApprovalGroupDbConverter
{
    internal static ApprovalWorkflowApprovalGroupDb FromDomain(ApprovalWorkflowDomesticApprovalGroup group)
    {
        ApprovalWorkflowApprovalParticipantDb[] participants =
            group.Participants.Select(ApprovalWorkflowApprovalParticipantDbConverter.FromDomain).ToArray();

        var asDomestic = new ApprovalWorkflowDomesticApprovalGroupDb
        {
            Participants = { participants }
        };

        var result = new ApprovalWorkflowApprovalGroupDb
        {
            AsDomestic = asDomestic
        };

        return result;
    }

    internal static ApprovalWorkflowDomesticApprovalGroup ToDomain(ApprovalWorkflowDomesticApprovalGroupDb group)
    {
        ApprovalWorkflowApprovalParticipant[] participants =
            group.Participants.Select(ApprovalWorkflowApprovalParticipantDbConverter.ToDomain).ToArray();

        var result = new ApprovalWorkflowDomesticApprovalGroup(participants);

        return result;
    }
}
