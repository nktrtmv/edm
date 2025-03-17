namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Audit.Briefs;

public sealed class AuditBriefBff
{
    public required PersonBff CreatedBy { get; init; }
    public required PersonBff UpdatedBy { get; init; }
    public required DateTime CreatedDateTime { get; init; }
    public required DateTime UpdatedDateTime { get; init; }
}
