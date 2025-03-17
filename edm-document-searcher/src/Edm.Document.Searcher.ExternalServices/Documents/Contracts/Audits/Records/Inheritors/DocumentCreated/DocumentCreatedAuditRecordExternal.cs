using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records.Headings;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records.Inheritors.DocumentCreated.Changes;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records.Inheritors.DocumentCreated;

public sealed record DocumentCreatedAuditRecordExternal(AuditRecordHeadingExternal Heading, DocumentAttributesValuesChangeExternal[] Change)
    : DocumentAuditRecordExternal(Heading);
