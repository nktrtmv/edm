using Edm.DocumentGenerator.Gateway.Core.Contracts.Audit.Briefs;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit;

public sealed class DocumentAuditBff
{
    public required AuditBriefBff Brief { get; init; }
    public required DocumentAuditRecordBff[] Records { get; init; }
}
