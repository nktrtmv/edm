using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Factories.Services.Analyzers.Collectors.AttributesIds.Conditions;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Factories.Services.Analyzers.Collectors.AttributesIds.Groups;

internal static class ApprovalGroupsAttributesIdsCollector
{
    internal static HashSet<int> Collect(ApprovalGroup[] groups)
    {
        var result = new HashSet<int>();

        foreach (ApprovalGroup group in groups)
        {
            Collect(result, group);
        }

        return result;
    }

    private static void Collect(HashSet<int> attributesIds, ApprovalGroup group)
    {
        None _ = group.Details switch
        {
            DomesticApprovalGroupDetails d => Collect(attributesIds, d),
            _ => throw new ArgumentTypeOutOfRangeException(group)
        };
    }

    private static None Collect(HashSet<int> attributesIds, DomesticApprovalGroupDetails details)
    {
        foreach (DomesticApprovalGroupParticipant participant in details.Participants)
        {
            EntityConditionAttributesIdsCollector.Collect(attributesIds, participant.Condition);
        }

        return default;
    }
}
