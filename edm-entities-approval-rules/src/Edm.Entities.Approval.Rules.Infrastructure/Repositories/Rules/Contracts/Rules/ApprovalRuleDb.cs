namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules;

internal sealed class ApprovalRuleDb
{
    internal required string DomainId { get; init; }
    internal required string EntityTypeId { get; init; }
    internal required DateTime EntityTypeUpdatedDate { get; init; }
    internal required int OriginalVersion { get; init; }
    internal required int Version { get; init; }
    internal required bool IsActive { get; init; }
    internal required string DisplayName { get; init; }
    internal required byte[] Data { get; init; }
    internal required string CreatedBy { get; init; }
    internal required string UpdatedBy { get; init; }
    internal required DateTime CreatedAt { get; init; }
    internal required DateTime UpdatedAt { get; init; }
    internal required DateTime ConcurrencyToken { get; init; }
    internal required bool IsDeleted { get; init; }
}
