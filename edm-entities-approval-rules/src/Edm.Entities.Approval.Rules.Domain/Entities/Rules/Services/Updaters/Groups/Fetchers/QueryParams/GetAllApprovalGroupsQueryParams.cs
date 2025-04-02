namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters.Groups.Fetchers.QueryParams;

public sealed class GetAllApprovalGroupsQueryParams
{
    public int Limit { get; }
    public int Skip { get; }
    public string? Search { get; }
    public string[]? ParticipantIds { get; }

    public GetAllApprovalGroupsQueryParams()
    {
        Limit = int.MaxValue;
    }

    public GetAllApprovalGroupsQueryParams(string? search, string[]? participantIds, int skip, int limit)
    {
        Search = search;
        ParticipantIds = participantIds;
        Skip = skip;
        Limit = limit;
    }
}
