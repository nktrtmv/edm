using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Processes;
using Edm.Document.Searcher.Presentation.Abstractions;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.DocumentStatuses;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Proccessed;

internal static class GetStepperQueryResponseStepsProcessedConverter
{
    internal static DocumentStepProcessedDto? FromInternal(DocumentStepProcessedInternal? step)
    {
        if (step is null)
        {
            return null;
        }

        var nextStatus = GetStepperQueryResponseStepsDocumentStatusConverter.FromInternal(step.NextStatus);

        var result = new DocumentStepProcessedDto
        {
            ProcessedBy = step.ProcessedBy ?? string.Empty,
            ProcessedDateTime = step.ProcessedDateTime.ToTimestamp(),
            NextStatus = nextStatus
        };

        return result;
    }
}
