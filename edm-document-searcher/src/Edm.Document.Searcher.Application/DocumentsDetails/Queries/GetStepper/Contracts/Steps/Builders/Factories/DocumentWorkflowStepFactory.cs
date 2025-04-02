using Edm.Document.Searcher.Application.Documents.Markers;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Processes;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Builders.Factories;

internal sealed class DocumentWorkflowStepFactory
{
    private int LastNumber { get; set; }
    private DocumentWorkflowStepInternal? LastStep { get; set; }

    internal DocumentWorkflowStepInternal Create(
        DocumentStatusInternal status,
        DateTime processedDateTime,
        string processedBy,
        string[]? stageOwners)
    {
        var result = new DocumentWorkflowStepInternal
        {
            Date = processedDateTime,
            Status = status,
            Number = LastNumber++,
            Responsible = stageOwners
        };

        if (LastStep is not null)
        {
            LastStep.Processed = new DocumentStepProcessedInternal(processedBy, processedDateTime, status);
        }

        LastStep = result;

        return result;
    }
}
