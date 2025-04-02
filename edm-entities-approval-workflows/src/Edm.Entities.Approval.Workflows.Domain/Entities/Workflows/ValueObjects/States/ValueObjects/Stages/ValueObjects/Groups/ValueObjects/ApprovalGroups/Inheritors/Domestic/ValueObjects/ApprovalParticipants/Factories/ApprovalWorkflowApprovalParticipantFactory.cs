using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.
    Domestic.ValueObjects.ApprovalParticipants.Factories;

public static class ApprovalWorkflowApprovalParticipantFactory
{
    public static ApprovalWorkflowApprovalParticipant Create(Id<Employee> id, Id<Employee>[] substituteEmployees, bool isSubstitutionDisabled)
    {
        ApprovalWorkflowApprovalParticipant result = CreateFromDb(id, substituteEmployees, isSubstitutionDisabled);

        return result;
    }

    public static ApprovalWorkflowApprovalParticipant CreateFromDb(Id<Employee> id, Id<Employee>[] substituteEmployees, bool isSubstitutionDisabled)
    {
        var result = new ApprovalWorkflowApprovalParticipant(id, substituteEmployees, isSubstitutionDisabled);

        return result;
    }
}
