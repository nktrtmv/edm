namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.GetAll.Contracts.Groups;

public sealed class GetAllApprovalGroupsQueryResponseGroupBff
{
    public required string Id { get; init; }
    public required string DisplayName { get; init; }
    public string? Label { get; init; }
}
