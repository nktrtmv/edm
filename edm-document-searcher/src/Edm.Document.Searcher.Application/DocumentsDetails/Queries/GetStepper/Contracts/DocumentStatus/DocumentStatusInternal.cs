using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Parameters;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Types;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus;

public sealed record DocumentStatusInternal(
    string Id,
    DocumentStatusTypeInternal Type,
    DocumentStatusParameterInternal[] Parameters,
    string SystemName,
    string DisplayName);
