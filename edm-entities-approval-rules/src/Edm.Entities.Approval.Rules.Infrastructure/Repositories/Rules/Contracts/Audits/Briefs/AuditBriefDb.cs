namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Audits.Briefs;

internal sealed class AuditBriefDb
{
    internal required string CreatedBy { get; init; }
    internal required string UpdatedBy { get; init; }
    internal required DateTime CreatedAt { get; init; }
    internal required DateTime UpdatedAt { get; init; }
}
