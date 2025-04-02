using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Domestic.Participants;
using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;

namespace Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Routes.Stages.Groups.Domestic.
    Participants;

internal static class ApprovalRouteParticipantDtoConverter
{
    internal static ApprovalParticipantInternal ToInternal(ApprovalRouteParticipantDto participant)
    {
        Id<EmployeeInternal> mainUserId =
            IdConverterFrom<EmployeeInternal>.FromString(participant.MainUserId);

        Id<EmployeeInternal>[] substituteUsersIds =
            participant.SubstituteUsersIds.Select(IdConverterFrom<EmployeeInternal>.FromString).ToArray();

        bool isSubstitutionDisabled = participant.IsSubstitutionDisabled;

        var result = new ApprovalParticipantInternal(mainUserId, substituteUsersIds, isSubstitutionDisabled);

        return result;
    }
}
