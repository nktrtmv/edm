using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records.Headings;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records.Inheritors.DocumentStatusChanged.Changes;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records.Inheritors.DocumentStatusChanged;

public sealed record DocumentStatusChangedAuditRecordExternal(AuditRecordHeadingExternal Heading, DocumentStatusChangeExternal Change)
    : DocumentAuditRecordExternal(Heading);
