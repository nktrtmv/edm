namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetAll.Contracts;

public sealed class GetAllApprovalRulesQueryBff
{
    public required string DomainId { get; init; }
    public string? Search { get; init; }
}
