using Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.AttributesValues;
using Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.Statuses;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records.Headings;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records.Inheritors.DocumentAttributesValuesChanged;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records.Inheritors.DocumentCreated;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records.Inheritors.DocumentCreated.Changes;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records.Inheritors.DocumentStatusChanged;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records.Inheritors.DocumentStatusChanged.Changes;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.Audit.Records;

public static class DocumentAuditRecordExternalConverter
{
    public static DocumentAuditRecordExternal FromDto(DocumentAuditRecordDto auditRecord, DocumentAuditDto audit)
    {
        var heading = new AuditRecordHeadingExternal(
            auditRecord.Heading.UpdatedById,
            auditRecord.Heading.UpdatedDateTime.ToDateTime());

        DocumentAuditRecordExternal result = auditRecord.ValueCase switch
        {
            DocumentAuditRecordDto.ValueOneofCase.AsStatusChanged => ToStatusChanged(auditRecord.AsStatusChanged, audit, heading),
            DocumentAuditRecordDto.ValueOneofCase.AsAttributeValuesChanged => ToAttributeValuesChanged(auditRecord.AsAttributeValuesChanged, heading),
            DocumentAuditRecordDto.ValueOneofCase.AsDocumentCreated => ToCreated(auditRecord.AsDocumentCreated, heading),
            _ => throw new ArgumentOutOfRangeException()
        };

        return result;
    }

    private static DocumentStatusChangedAuditRecordExternal ToStatusChanged(DocumentStatusChangedAuditRecordDto auditRecord, DocumentAuditDto audit, AuditRecordHeadingExternal heading)
    {
        var change = new DocumentStatusChangeExternal(
            DocumentStatusExternalConverter.FromDto(auditRecord.Change.From, audit),
            DocumentStatusExternalConverter.FromDto(auditRecord.Change.To, audit)
        );
        var result = new DocumentStatusChangedAuditRecordExternal(heading, change);

        return result;
    }

    private static DocumentAttributesValuesChangedAuditRecordExternal ToAttributeValuesChanged(DocumentAttributesValuesChangedAuditRecordDto auditRecord, AuditRecordHeadingExternal heading)
    {
        var change = auditRecord.Change.Select(
                x => new DocumentAttributesValuesChangeExternal(
                    DocumentAttributeValueExternalFromBareDtoConverter.FromDto(x.From),
                    DocumentAttributeValueExternalFromBareDtoConverter.FromDto(x.To)))
            .ToArray();

        var result = new DocumentAttributesValuesChangedAuditRecordExternal(heading, change);

        return result;
    }

    private static DocumentCreatedAuditRecordExternal ToCreated(DocumentCreatedAuditRecordDto auditRecord, AuditRecordHeadingExternal heading)
    {
        var change = auditRecord.Change.Select(
                x => new DocumentAttributesValuesChangeExternal(
                    DocumentAttributeValueExternalFromBareDtoConverter.FromDto(x.From),
                    DocumentAttributeValueExternalFromBareDtoConverter.FromDto(x.To)))
            .ToArray();

        var result = new DocumentCreatedAuditRecordExternal(heading, change);

        return result;
    }
}
