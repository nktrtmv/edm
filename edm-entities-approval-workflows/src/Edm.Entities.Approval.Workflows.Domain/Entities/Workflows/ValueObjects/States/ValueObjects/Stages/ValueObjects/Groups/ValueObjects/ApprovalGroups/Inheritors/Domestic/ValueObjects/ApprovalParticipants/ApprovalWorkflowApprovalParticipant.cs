using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.
    Domestic.ValueObjects.ApprovalParticipants;

public sealed class ApprovalWorkflowApprovalParticipant
{
    internal ApprovalWorkflowApprovalParticipant(Id<Employee> mainEmployeeId, Id<Employee>[] substituteEmployeesIds, bool isSubstitutionDisabled)
    {
        MainEmployeeId = mainEmployeeId;
        SubstituteEmployeesIds = substituteEmployeesIds;
        IsSubstitutionDisabled = isSubstitutionDisabled;
    }

    public Id<Employee> MainEmployeeId { get; }
    public Id<Employee>[] SubstituteEmployeesIds { get; }
    public bool IsSubstitutionDisabled { get; }

    public override string ToString()
    {
        string[] substituteUsersIds = SubstituteEmployeesIds.Select(IdConverterTo.ToString).ToArray();

        string substituteUsersIdsArray = string.Join(", ", substituteUsersIds);

        return $"{{ MainEmployeeId: {MainEmployeeId}, SubstituteEmployeesIds: [{substituteUsersIdsArray}] }}";
    }
}
