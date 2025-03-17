using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails;

public sealed class DocumentWorkflowStepperDetailsBff
{
    public required DocumentWorkflowStepBff[] Steps { get; init; } = Array.Empty<DocumentWorkflowStepBff>();
}
