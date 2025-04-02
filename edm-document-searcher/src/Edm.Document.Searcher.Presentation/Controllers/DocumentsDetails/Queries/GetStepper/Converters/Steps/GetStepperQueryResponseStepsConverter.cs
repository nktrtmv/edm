using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Signings;
using Edm.Document.Searcher.Presentation.Abstractions;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.DocumentStatuses;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Signings;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Simples;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Proccessed;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps;

internal static class GetStepperQueryResponseStepsConverter
{
    internal static DocumentWorkflowStepDto FromInternal(DocumentWorkflowStepInternal step)
    {
        var result = step switch
        {
            DocumentWorkflowApprovalStepInternal approval => ToApproval(approval),
            DocumentWorkflowSigningStepInternal signing => ToSigning(signing),
            not null => ToSimple(step),
            _ => throw new ArgumentOutOfRangeException(nameof(step), step, null)
        };

        result.Date = step.Date.ToTimestamp();
        result.Status = GetStepperQueryResponseStepsDocumentStatusConverter.FromInternal(step.Status);
        result.Processed = GetStepperQueryResponseStepsProcessedConverter.FromInternal(step.Processed);
        result.Number = step.Number;

        return result;
    }

    private static DocumentWorkflowStepDto ToApproval(DocumentWorkflowApprovalStepInternal step)
    {
        var result = new DocumentWorkflowStepDto
        {
            AsApproval = DocumentWorkflowApprovalStepConverter.FromInternal(step)
        };

        return result;
    }

    private static DocumentWorkflowStepDto ToSigning(DocumentWorkflowSigningStepInternal step)
    {
        var result = new DocumentWorkflowStepDto
        {
            AsSigning = DocumentWorkflowSigningStepConverter.FromInternal(step)
        };

        return result;
    }

    private static DocumentWorkflowStepDto ToSimple(DocumentWorkflowStepInternal step)
    {
        var result = new DocumentWorkflowStepDto
        {
            AsSimple = DocumentWorkflowSimpleStepConverter.FromInternal(step)
        };

        return result;
    }
}
