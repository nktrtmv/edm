using Edm.DocumentGenerator.Gateway.Core.Contracts.Audit.Briefs;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.Contracts.Audit;

public sealed class DocumentTemplateAuditBff
{
    public required AuditBriefBff Brief { get; init; }
}
