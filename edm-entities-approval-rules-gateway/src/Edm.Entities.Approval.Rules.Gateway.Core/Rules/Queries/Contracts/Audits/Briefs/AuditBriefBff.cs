using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Persons;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Contracts.Audits.Briefs;

public sealed class AuditBriefBff
{
    public required PersonBff CreatedBy { get; init; }
    public required PersonBff UpdatedBy { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required DateTime UpdatedAt { get; init; }
}
