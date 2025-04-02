using System.Text.Json.Serialization;

using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Groups;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Statuses;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages;

public sealed class EntitiesApprovalWorkflowStageInternal
{
    [JsonPropertyName("_id")]
    public required string Id { get; init; }

    public required int Number { get; init; }
    public required EntitiesApprovalWorkflowStageStatusInternal Status { get; init; }
    public required EntitiesApprovalWorkflowGroupInternal[] Groups { get; init; }
    public DateTime? StartedDate { get; init; }
}
