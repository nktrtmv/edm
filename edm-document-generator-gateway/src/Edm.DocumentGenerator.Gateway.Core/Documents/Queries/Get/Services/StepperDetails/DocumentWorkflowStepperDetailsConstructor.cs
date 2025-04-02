using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.StepperDetails.Steps.Builders;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.StepperDetails.Steps.Transformers.Inheritors.Approval;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.StepperDetails.Steps.Transformers.Inheritors.Signing;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.Workflows.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.StepperDetails;

internal static class DocumentWorkflowStepperDetailsConstructor
{
    internal static DocumentWorkflowStepperDetailsBff Construct(
        DocumentDetailedDto document,
        DocumentWorkflows workflows,
        DocumentConversionContext conversionContext)
    {
        var stepBuilder = new DocumentWorkflowStepBuilder(document, conversionContext);

        var approvalStepTransformer = new DocumentWorkflowApprovalStepTransformer(workflows.Approval, conversionContext);

        var signingStepTransformer = new DocumentWorkflowSigningStepTransformer(workflows.Signing, conversionContext);

        var steps = document.Audit.Records
            .Select(stepBuilder.Create)
            .OfType<DocumentWorkflowStepBff>()
            .Select(approvalStepTransformer.TryTransform)
            .Select(signingStepTransformer.TryTransform)
            .ToArray();

        var result = new DocumentWorkflowStepperDetailsBff
        {
            Steps = steps
        };

        return result;
    }
}
