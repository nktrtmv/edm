using Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.Audit.Records;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.Audit;

internal static class DocumentAuditExternalConverter
{
    public static DocumentAuditExternal FromDto(DocumentAuditDto audit)
    {
        UtcDateTime<DocumentAuditExternal> createdDate =
            UtcDateTimeConverterFrom<DocumentAuditExternal>.FromTimestamp(audit.Brief.CreatedDateTime);

        UtcDateTime<DocumentAuditExternal> updatedDate =
            UtcDateTimeConverterFrom<DocumentAuditExternal>.FromTimestamp(audit.Brief.UpdatedDateTime);

        UtcDateTime<DocumentStatusExternal>? lastMovedFromInitial = FetchLastMovedFromInitial(audit);

        DocumentAuditRecordExternal[] auditRecords = audit.Records.Select(r => DocumentAuditRecordExternalConverter.FromDto(r, audit)).ToArray();

        var result = new DocumentAuditExternal(createdDate, updatedDate, lastMovedFromInitial, auditRecords);

        return result;
    }

    private static UtcDateTime<DocumentStatusExternal>? FetchLastMovedFromInitial(DocumentAuditDto audit)
    {
        Timestamp? lastMovedFromInitial = audit.Records
            .Where(r => r.AsStatusChanged is not null)
            .LastOrDefault(s => s.AsStatusChanged.Change.From.Type is DocumentStatusTypeDto.Initial)
            ?.Heading.UpdatedDateTime;

        UtcDateTime<DocumentStatusExternal>? result =
            NullableConverter.Convert(lastMovedFromInitial, UtcDateTimeConverterFrom<DocumentStatusExternal>.FromTimestamp);

        return result;
    }
}
