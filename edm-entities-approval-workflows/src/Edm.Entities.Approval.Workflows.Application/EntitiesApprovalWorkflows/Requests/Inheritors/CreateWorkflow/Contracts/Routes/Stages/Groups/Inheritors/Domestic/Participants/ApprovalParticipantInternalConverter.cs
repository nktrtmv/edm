using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Domestic.ValueObjects.ApprovalParticipants;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Domestic.ValueObjects.ApprovalParticipants.Factories;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Domestic.
    Participants;

internal static class ApprovalParticipantInternalConverter
{
    public static ApprovalWorkflowApprovalParticipant ToDomain(ApprovalParticipantInternal participant)
    {
        Id<Employee> mainPersonId = IdConverterFrom<Employee>.From(participant.MainEmployeeId);

        Id<Employee>[] substitutePersonsIds =
            participant.SubstituteEmployeeIds.Select(IdConverterFrom<Employee>.From).ToArray();

        bool isSubstitutionDisabled = participant.IsSubstitutionDisabled;

        ApprovalWorkflowApprovalParticipant result =
            ApprovalWorkflowApprovalParticipantFactory.CreateFromDb(mainPersonId, substitutePersonsIds, isSubstitutionDisabled);

        return result;
    }
}
