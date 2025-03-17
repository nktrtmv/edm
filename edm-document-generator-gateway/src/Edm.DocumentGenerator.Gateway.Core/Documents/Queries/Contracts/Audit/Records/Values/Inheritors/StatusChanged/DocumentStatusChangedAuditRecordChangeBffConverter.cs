using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Values.Inheritors.StatusChanged;

internal static class DocumentStatusChangedAuditRecordChangeBffConverter
{
    public static DocumentStatusChangedAuditRecordChangeBff ToBff(DocumentStatusChangedAuditRecordChangeDto change)
    {
        var from = DocumentStatusBffConverter.ToBff(change.From);
        var to = DocumentStatusBffConverter.ToBff(change.To);

        var result = new DocumentStatusChangedAuditRecordChangeBff
        {
            From = from,
            To = to
        };

        return result;
    }
}
