using System.Text.Json.Serialization;

using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Groups.Statuses;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Groups;

public sealed class EntitiesApprovalWorkflowGroupBff
{
    [JsonPropertyName("_id")]
    public required string Id { get; init; }

    public required EntitiesApprovalWorkflowAssignmentBff[] Assignments { get; init; }
    public required string Name { get; init; }
    public required EntitiesApprovalWorkflowGroupStatusBff Status { get; init; }
}
