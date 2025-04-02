using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.StatusChanged.Changes.StatusTransitionParametersValues;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.StatusChanged.Changes;

public sealed class DocumentStatusChangedAuditRecordBff : DocumentAuditRecordValueBff
{
    public required DocumentStatusChangedAuditRecordChangeBff Change { get; init; }
    public required DocumentAuditStatusTransitionParameterValueBff[] StatusTransitionParametersValues { get; init; }
}
