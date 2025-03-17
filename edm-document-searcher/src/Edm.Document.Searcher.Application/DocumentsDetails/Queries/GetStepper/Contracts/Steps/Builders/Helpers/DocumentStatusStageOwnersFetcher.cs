using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Reference;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records.Inheritors.DocumentAttributesValuesChanged;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records.Inheritors.DocumentCreated;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records.Inheritors.DocumentStatusChanged;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters.Inheritors.ReferenceAttributes;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters.Kinds;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Builders.Helpers;

internal static class DocumentStatusStageOwnersFetcher
{
    public static string[]? FetchIds(DocumentStatusExternal statusChange, DocumentAuditRecordExternal auditRecord, DocumentAuditRecordExternal[] documentAuditRecords)
    {
        DocumentStatusParameterExternal? parameter =
            statusChange.Parameters.FirstOrDefault(p => p.Kind is DocumentStatusParameterKindExternal.StageOwner);

        if (parameter is not ReferenceAttributeDocumentStatusParameterExternal referenceAttribute)
        {
            return null;
        }

        string? attributeId = referenceAttribute.Values.FirstOrDefault();

        if (string.IsNullOrWhiteSpace(attributeId))
        {
            return null;
        }

        var result = FetchLastStageOwnersIdsForCurrentStatus(attributeId, auditRecord, documentAuditRecords.ToList());

        return result;
    }

    private static string[]? FetchLastStageOwnersIdsForCurrentStatus(
        string attributeId,
        DocumentAuditRecordExternal statusAuditRecord,
        List<DocumentAuditRecordExternal> documentAuditRecords)
    {
        int auditRecordsCount = documentAuditRecords.Count;

        int currentStatusAuditIndex = documentAuditRecords.IndexOf(statusAuditRecord);

        bool currentStatusAuditIsLastAudit = currentStatusAuditIndex == auditRecordsCount - 1;

        DocumentAuditRecordExternal? nextStatusAudit = currentStatusAuditIsLastAudit
            ? null
            : documentAuditRecords[(currentStatusAuditIndex + 1)..].FirstOrDefault(a => a is DocumentStatusChangedAuditRecordExternal);

        int lastSearchAuditIndex = nextStatusAudit is null
            ? auditRecordsCount
            : documentAuditRecords.IndexOf(nextStatusAudit);

        List<DocumentAuditRecordExternal> currentDocumentAuditRecords = documentAuditRecords[..lastSearchAuditIndex];

        var documentCreatedChanges = currentDocumentAuditRecords
            .OfType<DocumentCreatedAuditRecordExternal>()
            .SelectMany(x => x.Change);

        var documentAttributesValuesChanges = currentDocumentAuditRecords
            .OfType<DocumentAttributesValuesChangedAuditRecordExternal>()
            .SelectMany(x => x.Change);

        var lastOrDefaultChange = documentCreatedChanges
            .Union(documentAttributesValuesChanges)
            .LastOrDefault(a => a.To.Attribute.Data.Id == attributeId && a.To is DocumentReferenceAttributeValueExternal);

        if (lastOrDefaultChange?.To is not DocumentReferenceAttributeValueExternal changeTo)
        {
            return null;
        }

        var result = changeTo.Values;

        return result;
    }
}
