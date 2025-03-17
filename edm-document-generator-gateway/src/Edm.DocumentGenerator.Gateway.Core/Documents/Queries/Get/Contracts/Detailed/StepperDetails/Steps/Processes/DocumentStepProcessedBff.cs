using Edm.DocumentGenerator.Gateway.Core.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Processes;

public sealed class DocumentStepProcessedBff
{
    public required PersonBff ProcessedBy { get; init; }
    public required DateTime ProcessedDateTime { get; init; }
    public required DocumentStatusBff NextStatus { get; init; }
}
