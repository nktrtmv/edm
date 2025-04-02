namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters.Groups.Fetchers.QueryParams.Factories;

public static class GetAllApprovalGroupsQueryParamsFactory
{
    public static GetAllApprovalGroupsQueryParams CreateFrom(string? search, string[]? participantIds, int skip, int limit)
    {
        var result = new GetAllApprovalGroupsQueryParams(search, participantIds, skip, limit);

        return result;
    }
}
