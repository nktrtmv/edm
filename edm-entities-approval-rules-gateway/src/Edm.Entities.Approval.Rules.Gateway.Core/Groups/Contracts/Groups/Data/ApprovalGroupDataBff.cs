namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Data;

public sealed class ApprovalGroupDataBff
{
    public required string Id { get; init; }
    public required string DisplayName { get; init; }
    public required string? Label { get; init; }
}
