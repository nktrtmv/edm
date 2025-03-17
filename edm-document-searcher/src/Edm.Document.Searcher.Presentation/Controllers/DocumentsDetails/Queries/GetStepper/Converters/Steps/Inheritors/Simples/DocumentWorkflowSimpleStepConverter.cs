using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps;
using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Simples;

internal static class DocumentWorkflowSimpleStepConverter
{
    internal static DocumentWorkflowSimpleStepDto FromInternal(DocumentWorkflowStepInternal step)
    {
        var result = new DocumentWorkflowSimpleStepDto
        {
            Responsible = { step.Responsible ?? [] }
        };

        return result;
    }
}
