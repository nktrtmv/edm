using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.StatusChanged;

public sealed class DocumentStatusChangedAuditRecordChangeBff
{
    public required DocumentStatusBff From { get; init; }
    public required DocumentStatusBff To { get; init; }
}
