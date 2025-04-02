using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Signings.Stages;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Signings;

public sealed class DocumentWorkflowSigningStepInternal : DocumentWorkflowStepInternal
{
    public DocumentSigningStageDetailsInternal[] Stages { get; init; } = Array.Empty<DocumentSigningStageDetailsInternal>();
}
