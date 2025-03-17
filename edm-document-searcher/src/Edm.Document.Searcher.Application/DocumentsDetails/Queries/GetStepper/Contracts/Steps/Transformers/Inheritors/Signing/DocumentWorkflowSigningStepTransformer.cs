using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Types;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Signings;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Signings.Stages;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Enrichment.Contexts;
using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Transformers.Inheritors.Signing;

internal sealed class DocumentWorkflowSigningStepTransformer : DocumentWorkflowStepTransformer<SigningWorkflowExternal>
{
    internal DocumentWorkflowSigningStepTransformer(
        SigningWorkflowExternal[] workflows,
        DocumentConversionContext conversionContext)
        : base(workflows, DocumentStatusTypeInternal.Signing, conversionContext)
    {
    }

    protected override DocumentWorkflowStepInternal Transform(DocumentWorkflowStepInternal step, SigningWorkflowExternal workflow)
    {
        var number = 1;

        var stages = workflow.Stages
            .Select(s => DocumentSigningStageDetailsInternalConverter.FromExternal(s, number++, ConversionContext))
            .ToArray();

        var result = new DocumentWorkflowSigningStepInternal
        {
            Number = step.Number,
            Status = step.Status,
            Date = step.Date,
            Stages = stages,
            Responsible = step.Responsible
        };

        return result;
    }
}
