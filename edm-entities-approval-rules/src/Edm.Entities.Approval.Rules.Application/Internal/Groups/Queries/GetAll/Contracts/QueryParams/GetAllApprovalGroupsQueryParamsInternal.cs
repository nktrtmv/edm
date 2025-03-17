namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.GetAll.Contracts.QueryParams;

public sealed record GetAllApprovalGroupsQueryParamsInternal(string? Search, string[]? ParticipantIds, int Skip, int Limit);
