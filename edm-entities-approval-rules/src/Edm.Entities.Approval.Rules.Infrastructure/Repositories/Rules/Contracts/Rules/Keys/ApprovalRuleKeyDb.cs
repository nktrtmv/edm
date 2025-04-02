namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Keys;

internal sealed class ApprovalRuleKeyDb
{
    internal required string DomainId { get; init; }
    internal required string EntityTypeId { get; init; }
    internal required DateTime EntityTypeUpdatedDate { get; init; }
    internal required int Version { get; init; }
}
