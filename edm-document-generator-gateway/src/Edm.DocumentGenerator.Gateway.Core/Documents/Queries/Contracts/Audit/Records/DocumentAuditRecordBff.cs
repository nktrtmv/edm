using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Headings;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records;

public sealed class DocumentAuditRecordBff
{
    public required AuditRecordHeadingBff Heading { get; init; }
    public required DocumentAuditRecordValueBff Value { get; init; }
}
