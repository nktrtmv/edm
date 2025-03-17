using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters.Groups.Fetchers.QueryParams;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters.Groups.Fetchers;

public static class ApprovalGroupsFetcher
{
    public static ApprovalGroup[] GetAll(ApprovalRule rule, GetAllApprovalGroupsQueryParams queryParams)
    {
        ApprovalGroup[] groups = rule.Groups;

        if (!string.IsNullOrWhiteSpace(queryParams.Search) || queryParams.ParticipantIds?.Length > 0)
        {
            groups = groups
                .Where(g => IsMatched(g, queryParams.Search, queryParams.ParticipantIds))
                .ToArray();
        }

        ApprovalGroup[] result = groups
            .OrderBy(r => r.DisplayName)
            .Skip(queryParams.Skip)
            .Take(queryParams.Limit)
            .ToArray();

        return result;
    }

    public static ApprovalGroup GetRequired(ApprovalRule rule, Id<ApprovalGroup> id)
    {
        ApprovalGroup result = rule.Groups.Single(r => r.Id == id);

        return result;
    }

    private static bool IsMatched(ApprovalGroup group, string? search, string[]? participantIds)
    {
        if (!string.IsNullOrEmpty(search))
        {
            if (!group.Data.DisplayName.Contains(search, StringComparison.OrdinalIgnoreCase)
                && group.Data.Label?.Contains(search, StringComparison.OrdinalIgnoreCase) != true)
            {
                return false;
            }
        }

        if (participantIds?.Length > 0)
        {
            if (group.Details is not DomesticApprovalGroupDetails domestic)
            {
                return false;
            }

            if (!domestic.Participants.Any(
                    p =>
                        participantIds.Contains(p.MainParticipantSource.ToString()) ||
                        p.SubstituteParticipantsSources.Any(
                            su =>
                                participantIds.Contains(su.ToString()))))
            {
                return false;
            }
        }

        return true;
    }
}
