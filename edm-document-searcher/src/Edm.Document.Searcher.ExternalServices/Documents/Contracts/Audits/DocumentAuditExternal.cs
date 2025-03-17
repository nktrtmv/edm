using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits;

public sealed record DocumentAuditExternal(
    UtcDateTime<DocumentAuditExternal> CreatedDate,
    UtcDateTime<DocumentAuditExternal> UpdatedDate,
    UtcDateTime<DocumentStatusExternal>? LastMovedFromInitial,
    DocumentAuditRecordExternal[] Records);
