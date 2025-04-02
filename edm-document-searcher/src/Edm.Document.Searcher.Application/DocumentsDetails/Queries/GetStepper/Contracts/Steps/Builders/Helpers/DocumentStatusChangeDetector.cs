using Edm.Document.Searcher.ExternalServices.Documents.Contracts;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records.Inheritors.DocumentCreated;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records.Inheritors.DocumentStatusChanged;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses;
using Edm.Document.Searcher.GenericSubdomain.Extensions.Types;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Builders.Helpers;

internal static class DocumentStatusChangeDetector
{
    internal static DocumentStatusExternal? GetStatusChangeFromAuditRecord(DocumentAuditRecordExternal auditRecord, DocumentExternal document)
    {
        DocumentStatusExternal? result = auditRecord switch
        {
            DocumentCreatedAuditRecordExternal => GetStatusFromDocument(document),

            DocumentStatusChangedAuditRecordExternal => GetStatusToAuditRecord(auditRecord),

            _ => null
        };

        return result;
    }

    private static DocumentStatusExternal GetStatusToAuditRecord(DocumentAuditRecordExternal record)
    {
        DocumentStatusChangedAuditRecordExternal asStatusChange = TypeCasterTo<DocumentStatusChangedAuditRecordExternal>.CastRequired(record);

        DocumentStatusExternal result = asStatusChange.Change.To;

        return result;
    }

    private static DocumentStatusExternal GetStatusFromDocument(DocumentExternal document)
    {
        DocumentAuditRecordExternal? firstStatusChangedRecord = document.Audit.Records
            .FirstOrDefault(r => r is DocumentStatusChangedAuditRecordExternal);

        if (firstStatusChangedRecord is null)
        {
            return document.Status;
        }

        DocumentStatusChangedAuditRecordExternal asStatusChange = TypeCasterTo<DocumentStatusChangedAuditRecordExternal>.CastRequired(firstStatusChangedRecord);

        DocumentStatusExternal result = asStatusChange.Change.From;

        return result;
    }
}
