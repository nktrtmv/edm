using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Signings.Stages;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Signings;

public sealed class DocumentWorkflowSigningStepBff : DocumentWorkflowStepBff
{
    public DocumentSigningStageDetailsBff[] Stages { get; init; } = Array.Empty<DocumentSigningStageDetailsBff>();
}
