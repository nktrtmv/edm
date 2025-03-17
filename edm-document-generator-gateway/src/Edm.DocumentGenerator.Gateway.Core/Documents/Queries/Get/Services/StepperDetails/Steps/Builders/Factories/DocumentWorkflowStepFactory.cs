using Edm.DocumentGenerator.Gateway.Core.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Processes;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.StepperDetails.Steps.Builders.Factories;

internal sealed class DocumentWorkflowStepFactory
{
    private int LastNumber { get; set; }
    private DocumentWorkflowStepBff? LastStep { get; set; }

    internal DocumentWorkflowStepBff Create(DocumentStatusBff status, DateTime processedDateTime, PersonBff processedBy)
    {
        var result = new DocumentWorkflowStepBff
        {
            Date = processedDateTime,
            Status = status,
            Number = LastNumber++
        };

        if (LastStep is not null)
        {
            LastStep.Processed = new DocumentStepProcessedBff
            {
                ProcessedBy = processedBy,
                ProcessedDateTime = processedDateTime,
                NextStatus = status
            };
        }

        LastStep = result;

        return result;
    }
}
