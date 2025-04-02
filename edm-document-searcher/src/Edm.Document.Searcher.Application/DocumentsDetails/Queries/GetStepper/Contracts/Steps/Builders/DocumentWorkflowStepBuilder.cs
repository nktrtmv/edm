using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Builders.Factories;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Builders.Helpers;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Builders;

internal sealed class DocumentWorkflowStepBuilder(DocumentExternal document)
{
    private DocumentWorkflowStepFactory Factory { get; } = new DocumentWorkflowStepFactory();

    internal DocumentWorkflowStepInternal? Create(DocumentAuditRecordExternal auditRecord, DocumentAuditRecordExternal[] documentAuditRecords)
    {
        var statusChange = DocumentStatusChangeDetector.GetStatusChangeFromAuditRecord(auditRecord, document);

        if (statusChange is null)
        {
            return null;
        }

        var status = DocumentStatusInternalConverter.ToInternal(statusChange);

        var processedDateTime = auditRecord.Heading.UpdatedDateTime;
        var personId = auditRecord.Heading.UpdateById;

        string[]? stageOwnersIds = DocumentStatusStageOwnersFetcher.FetchIds(statusChange, auditRecord, documentAuditRecords);

        var result = Factory.Create(status, processedDateTime, personId, stageOwnersIds);

        return result;
    }
}
