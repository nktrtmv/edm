using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.GetAll.Contracts.Filtering;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.GetAll.Contracts;

internal static class GetAllApprovalGroupsQueryBffConverter
{
    internal static GetAllApprovalGroupsQuery ToDto(
        GetAllApprovalGroupsQueryBff query,
        FilteringParametersDto filtering,
        int skip,
        int limit)
    {
        var approvalRuleKey = ApprovalRuleKeyBffConverter.ToDto(query.ApprovalRuleKey);

        var queryParams = new GetAllApprovalGroupsQueryParamsDto
        {
            Search = filtering.Search,
            Limit = limit,
            Skip = skip
        };

        if (filtering.ParticipantIds != null)
        {
            queryParams.ParticipantIds.AddRange(filtering.ParticipantIds);
        }

        var result = new GetAllApprovalGroupsQuery
        {
            ApprovalRuleKey = approvalRuleKey,
            QueryParams = queryParams
        };

        return result;
    }
}
