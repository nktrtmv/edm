using System.Text.Json.Serialization;

using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Groups.Statuses;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Groups;

public sealed class EntitiesApprovalWorkflowGroupInternal
{
    [JsonPropertyName("_id")]
    public required string Id { get; init; }

    public required EntitiesApprovalWorkflowAssignmentInternal[] Assignments { get; init; }
    public required string Name { get; init; }
    public required EntitiesApprovalWorkflowGroupStatusInternal Status { get; init; }
}
