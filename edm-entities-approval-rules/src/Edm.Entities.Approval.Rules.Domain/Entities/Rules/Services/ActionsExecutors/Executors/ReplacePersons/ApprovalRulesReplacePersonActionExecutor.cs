using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants.Sources;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants.Sources.Inheritors;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.ActionsExecutors.Actions.Inheritors;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Detectors.ContainsPerson;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters.Groups.Updaters;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.ActionsExecutors.Executors.ReplacePersons;

internal static class ApprovalRulesReplacePersonActionExecutor
{
    internal static None ReplacePerson(ApprovalRule rule, ApprovalRulesReplacePersonAction action)
    {
        bool ruleContainsPersonsToReplace = RuleContainsPersonApprovalRuleDetector.Contains(rule, action.PersonFromId);

        if (!ruleContainsPersonsToReplace)
        {
            return default;
        }

        foreach (ApprovalGroup group in rule.Groups)
        {
            ApprovalGroup updatedGroup = Replace(group, action);

            ApprovalGroupsUpdater.UpdateGroup(rule, updatedGroup);
        }

        return default;
    }

    private static ApprovalGroup Replace(ApprovalGroup group, ApprovalRulesReplacePersonAction action)
    {
        ApprovalGroup result = group.Details switch
        {
            DomesticApprovalGroupDetails d => Replace(d, group, action),
            _ => throw new ArgumentTypeOutOfRangeException(group)
        };

        return result;
    }

    private static ApprovalGroup Replace(DomesticApprovalGroupDetails details, ApprovalGroup group, ApprovalRulesReplacePersonAction action)
    {
        DomesticApprovalGroupParticipant[] participants = details.Participants
            .Select(p => Replace(p, action))
            .ToArray();

        DomesticApprovalGroupDetails updatedDetails =
            DomesticApprovalGroupDetailsFactory.CreateFrom(details.Options, participants);

        ApprovalGroup result = ApprovalGroupFactory.CreateFrom(group.Data, updatedDetails);

        return result;
    }

    private static DomesticApprovalGroupParticipant Replace(DomesticApprovalGroupParticipant participant, ApprovalRulesReplacePersonAction action)
    {
        DomesticApprovalGroupParticipantSource mainParticipantSource = Replace(participant.MainParticipantSource, action);

        DomesticApprovalGroupParticipantSource[] substituteParticipantsSources = participant.SubstituteParticipantsSources
            .Select(s => Replace(s, action))
            .ToArray();

        bool isSubstitutionDisabled = participant.IsSubstitutionDisabled;

        var result = new DomesticApprovalGroupParticipant(mainParticipantSource, substituteParticipantsSources, participant.Condition, isSubstitutionDisabled);

        return result;
    }

    private static DomesticApprovalGroupParticipantSource Replace(
        DomesticApprovalGroupParticipantSource originalParticipantSource,
        ApprovalRulesReplacePersonAction action)
    {
        if (originalParticipantSource is not UserDomesticApprovalGroupParticipantSource userIdSource)
        {
            return originalParticipantSource;
        }

        DomesticApprovalGroupParticipantSource result = userIdSource.UserId == action.PersonFromId
            ? new UserDomesticApprovalGroupParticipantSource(action.PersonToId)
            : originalParticipantSource;

        return result;
    }
}
