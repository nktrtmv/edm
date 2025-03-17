using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.
    Domestic.ValueObjects.ApprovalParticipants;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.
    Domestic.ValueObjects.ApprovalParticipants.Factories;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.ApprovalGroups.Inheritors.Domestic.
    ApprovalParticipants;

internal static class ApprovalWorkflowApprovalParticipantDbConverter
{
    internal static ApprovalWorkflowApprovalParticipantDb FromDomain(ApprovalWorkflowApprovalParticipant participant)
    {
        var mainEmployeeId = participant.MainEmployeeId.ToString();

        string[] substituteEmployeesIds = participant.SubstituteEmployeesIds.Select(IdConverterTo.ToString).ToArray();

        bool isSubstitutionDisabled = participant.IsSubstitutionDisabled;

        var result = new ApprovalWorkflowApprovalParticipantDb
        {
            MainEmployeeId = mainEmployeeId,
            SubstituteEmployeesIds = { substituteEmployeesIds },
            IsSubstitutionDisabled = isSubstitutionDisabled
        };

        return result;
    }

    internal static ApprovalWorkflowApprovalParticipant ToDomain(ApprovalWorkflowApprovalParticipantDb participant)
    {
        Id<Employee> mainEmployeeId = IdConverterFrom<Employee>.FromString(participant.MainEmployeeId);

        Id<Employee>[] substituteEmployeesIds = participant.SubstituteEmployeesIds.Select(IdConverterFrom<Employee>.FromString).ToArray();

        bool isSubstitutionDisabled = participant.IsSubstitutionDisabled;

        ApprovalWorkflowApprovalParticipant result = ApprovalWorkflowApprovalParticipantFactory.CreateFromDb(
            mainEmployeeId, substituteEmployeesIds, isSubstitutionDisabled);

        return result;
    }
}
