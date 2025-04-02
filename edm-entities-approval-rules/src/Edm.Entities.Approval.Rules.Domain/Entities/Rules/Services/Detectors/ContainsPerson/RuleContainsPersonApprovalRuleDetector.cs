using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants.Sources;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants.Sources.Inheritors;
using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Detectors.ContainsPerson;

internal static class RuleContainsPersonApprovalRuleDetector
{
    internal static bool Contains(ApprovalRule rule, Id<User> userId)
    {
        bool result = rule.Groups
            .Any(g => Contains(g, userId));

        return result;
    }

    private static bool Contains(ApprovalGroup group, Id<User> userId)
    {
        bool result = group.Details switch
        {
            DomesticApprovalGroupDetails d => Contains(d, userId),
            _ => throw new ArgumentTypeOutOfRangeException(group)
        };

        return result;
    }

    private static bool Contains(DomesticApprovalGroupDetails details, Id<User> userId)
    {
        bool result = details.Participants
            .Any(p => Contains(p.MainParticipantSource, userId));

        if (result)
        {
            return true;
        }

        result = details.Participants
            .Any(p => p.SubstituteParticipantsSources.Any(s => Contains(s, userId)));

        return result;
    }

    private static bool Contains(DomesticApprovalGroupParticipantSource participantSource, Id<User> userId)
    {
        if (participantSource is not UserDomesticApprovalGroupParticipantSource userIdParticipantSource)
        {
            return false;
        }

        bool result = userIdParticipantSource.UserId == userId;

        return result;
    }
}
