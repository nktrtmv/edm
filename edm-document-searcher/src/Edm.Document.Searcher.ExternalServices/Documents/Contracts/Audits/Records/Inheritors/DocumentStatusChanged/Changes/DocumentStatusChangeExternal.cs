using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.Audits.Records.Inheritors.DocumentStatusChanged.Changes;

public sealed record DocumentStatusChangeExternal(DocumentStatusExternal From, DocumentStatusExternal To);
