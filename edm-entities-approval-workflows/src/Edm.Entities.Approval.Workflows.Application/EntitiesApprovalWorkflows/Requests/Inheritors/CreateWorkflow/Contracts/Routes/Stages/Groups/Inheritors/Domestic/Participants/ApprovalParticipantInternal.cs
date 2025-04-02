using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Domestic.
    Participants;

public sealed class ApprovalParticipantInternal
{
    public ApprovalParticipantInternal(Id<EmployeeInternal> mainEmployeeId, Id<EmployeeInternal>[] substituteEmployeeIds, bool isSubstitutionDisabled)
    {
        MainEmployeeId = mainEmployeeId;
        SubstituteEmployeeIds = substituteEmployeeIds;
        IsSubstitutionDisabled = isSubstitutionDisabled;
    }

    public Id<EmployeeInternal> MainEmployeeId { get; }
    public Id<EmployeeInternal>[] SubstituteEmployeeIds { get; }
    public bool IsSubstitutionDisabled  { get; }
}
