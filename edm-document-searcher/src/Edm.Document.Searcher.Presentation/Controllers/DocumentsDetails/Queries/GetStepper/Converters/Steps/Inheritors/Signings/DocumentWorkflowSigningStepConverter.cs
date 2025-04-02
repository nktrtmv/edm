using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Signings;
using Edm.Document.Searcher.Presentation.Abstractions;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Signings.Stages;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Signings;

internal static class DocumentWorkflowSigningStepConverter
{
    internal static DocumentWorkflowSigningStepDto FromInternal(DocumentWorkflowSigningStepInternal step)
    {
        var stages = step.Stages.Select(DocumentSigningStageDetailsConverter.FromInternal);

        var result = new DocumentWorkflowSigningStepDto
        {
            Stages = { stages }
        };

        return result;
    }
}
