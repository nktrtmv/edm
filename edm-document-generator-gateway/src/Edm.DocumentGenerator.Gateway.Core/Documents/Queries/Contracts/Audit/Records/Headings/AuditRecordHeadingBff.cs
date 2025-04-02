using Edm.DocumentGenerator.Gateway.Core.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Headings;

public sealed class AuditRecordHeadingBff
{
    public required PersonBff UpdatedBy { get; init; }
    public required DateTime UpdatedDateTime { get; init; }
}
