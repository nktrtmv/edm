using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Types;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Signings;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Signings.Stages;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.StepperDetails.Steps.Transformers.Inheritors.Signing;

internal sealed class DocumentWorkflowSigningStepTransformer : DocumentWorkflowStepTransformer<SigningWorkflowExternal>
{
    internal DocumentWorkflowSigningStepTransformer(
        SigningWorkflowExternal[] workflows,
        DocumentConversionContext conversionContext)
        : base(workflows, DocumentStatusTypeBff.Signing, conversionContext)
    {
    }

    protected override DocumentWorkflowStepBff Transform(DocumentWorkflowStepBff step, SigningWorkflowExternal workflow)
    {
        var number = 1;

        DocumentSigningStageDetailsBff[] stages = workflow.Stages
            .Select(s => DocumentSigningStageDetailsBffConverter.FromExternal(s, number++, ConversionContext))
            .ToArray();

        var result = new DocumentWorkflowSigningStepBff
        {
            Number = step.Number,
            Status = step.Status,
            Date = step.Date,
            Stages = stages
        };

        return result;
    }
}
