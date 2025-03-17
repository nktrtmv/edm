using System.Text.Json.Serialization;

using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Groups;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Statuses;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages;

public sealed class EntitiesApprovalWorkflowStageBff
{
    [JsonPropertyName("_id")]
    public required string Id { get; init; }

    public required int Number { get; init; }
    public required EntitiesApprovalWorkflowStageStatusBff Status { get; init; }
    public required EntitiesApprovalWorkflowGroupBff[] Groups { get; init; }
    public DateTime? StartedDate { get; init; }
}
