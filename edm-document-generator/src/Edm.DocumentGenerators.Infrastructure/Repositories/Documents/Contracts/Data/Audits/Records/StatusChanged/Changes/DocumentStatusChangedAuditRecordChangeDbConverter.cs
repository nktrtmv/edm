using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Changes;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records.StatusChanged.Changes;

internal static class DocumentStatusChangedAuditRecordChangeDbConverter
{
    internal static DocumentStatusChangedAuditRecordChangeDb FromDomain(AuditRecordChange<Id<DocumentStatus>> change)
    {
        var from = IdConverterTo.ToString(change.From);

        var to = IdConverterTo.ToString(change.To);

        var result = new DocumentStatusChangedAuditRecordChangeDb
        {
            From = from,
            To = to
        };

        return result;
    }

    internal static AuditRecordChange<Id<DocumentStatus>> ToDomain(DocumentStatusChangedAuditRecordChangeDb change)
    {
        Id<DocumentStatus> from = IdConverterFrom<DocumentStatus>.FromString(change.From);

        Id<DocumentStatus> to = IdConverterFrom<DocumentStatus>.FromString(change.To);

        var result = new AuditRecordChange<Id<DocumentStatus>>(from, to);

        return result;
    }
}
