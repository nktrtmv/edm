using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records.Headings;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records.Inheritors.DocumentCreated.Changes;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records.Inheritors.DocumentAttributesValuesChanged;

public sealed record DocumentAttributesValuesChangedAuditRecordExternal(AuditRecordHeadingExternal Heading, DocumentAttributesValuesChangeExternal[] Change)
    : DocumentAuditRecordExternal(Heading);
