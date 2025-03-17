using Edm.DocumentGenerator.Gateway.Core.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Signings.Stages.Statuses;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Signings.Stages.Types;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Signings.Stages;

public sealed record DocumentSigningStageDetailsBff
{
    public required int Number { get; init; }
    public required DocumentSigningStageTypeBff StageType { get; init; }
    public required PersonBff Executor { get; init; }
    public required DocumentSigningStageStatusBff Status { get; init; }
    public required DateTime StatusChangedAt { get; init; }
    public required string? CompletionComment { get; init; }
    public ContractorBff? Contractor { get; init; }
}
