using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Options;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.Services.Finders.Services.Builders.Services.Builders.Stages.Services.Builders.Domestic.Services.Participants;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.ValueObjects.Groups.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.ValueObjects.Groups.Inheritors.Domestic.ValueObjects.Participants;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.Services.Finders.Services.Builders.Services.Builders.Stages.Services.Builders.Domestic;

internal static class DomesticRouteGroupBuilder
{
    internal static DomesticRouteGroup? Build(DomesticApprovalGroupDetails details, ApprovalGroup group, Entity entity, ApprovalRule approvalRule)
    {
        try
        {
            RouteParticipant[] participants = Build(details, entity, approvalRule);

            if (participants.Length == 0)
            {
                return null;
            }

            var result = new DomesticRouteGroup(group.Name, participants);

            return result;
        }
        catch (Exception e)
        {
            throw new ApplicationException($"Failed to create group.\nGroup: {group}", e);
        }
    }

    private static RouteParticipant[] Build(DomesticApprovalGroupDetails details, Entity entity, ApprovalRule approvalRule)
    {
        DomesticApprovalGroupParticipant[] participants = details.Participants
            .Where(p => p.Condition.IsMet(entity))
            .ToArray();

        Validate(participants, details.Options);

        RouteParticipant[] result = participants
            .Select(p => RouteParticipantBuilder.Build(p, entity, approvalRule))
            .ToArray();

        return result;
    }

    private static void Validate(DomesticApprovalGroupParticipant[] persons, DomesticApprovalGroupOptions options)
    {
        if (persons.Length == 0 && options.EmptyGroupIsAllowed == false)
        {
            throw new ApplicationException($"After applying conditions on domestic approval group there should be at least 1 participant, but found {persons.Length}.");
        }

        if (persons.Length > 1 && options.MultipleParticipantsAreAllowed == false)
        {
            throw new ApplicationException($"After applying conditions on single participant group there should be exactly 1 participant, but found {persons.Length}.");
        }
    }
}
