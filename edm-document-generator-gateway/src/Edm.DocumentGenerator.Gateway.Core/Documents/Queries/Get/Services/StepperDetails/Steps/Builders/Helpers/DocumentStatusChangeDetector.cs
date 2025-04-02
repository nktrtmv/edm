using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.StepperDetails.Steps.Builders.Helpers;

internal static class DocumentStatusChangeDetector
{
    internal static DocumentStatusDto? GetStatusChangeFromAuditRecord(DocumentAuditRecordDto record, DocumentDetailedDto document)
    {
        var result = record.ValueCase switch
        {
            DocumentAuditRecordDto.ValueOneofCase.AsDocumentCreated =>
                GetStatusFromDocument(document),

            DocumentAuditRecordDto.ValueOneofCase.AsStatusChanged =>
                record.AsStatusChanged.Change.To,

            _ => null
        };

        return result;
    }

    private static DocumentStatusDto GetStatusFromDocument(DocumentDetailedDto document)
    {
        var firstStatusChangedRecord = document.Audit.Records
            .FirstOrDefault<DocumentAuditRecordDto>(r => r.ValueCase == DocumentAuditRecordDto.ValueOneofCase.AsStatusChanged);

        if (firstStatusChangedRecord is null)
        {
            return document.Status;
        }

        var result = firstStatusChangedRecord.AsStatusChanged.Change.From;

        return result;
    }
}
