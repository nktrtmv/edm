using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Signings.Stages.Statuses;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Signings.Stages.Types;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Signings.Stages;

public sealed record DocumentSigningStageDetailsInternal(
    int Number,
    DocumentSigningStageTypeInternal StageType,
    ContractorInternal? Contractor,
    string Executor,
    DocumentSigningStageStatusInternal Status,
    DateTime StatusChangedAt,
    string? CompletionComment,
    string Id);
