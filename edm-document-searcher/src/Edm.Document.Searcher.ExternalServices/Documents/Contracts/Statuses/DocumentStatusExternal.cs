using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Types;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses;

public sealed record DocumentStatusExternal(
    Id<DocumentStatusExternal> Id,
    string DisplayName,
    DocumentStatusTypeExternal Type,
    UtcDateTime<DocumentStatusExternal> StartedDate,
    string SystemName,
    DocumentStatusParameterExternal[] Parameters);
