using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Statuses;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Types;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages;

public sealed class EntitiesApprovalWorkflowStageExternal
{
    public EntitiesApprovalWorkflowStageExternal(
        string id,
        EntitiesApprovalWorkflowStageTypeExternal type,
        EntitiesApprovalWorkflowStageStatusExternal status,
        EntitiesApprovalWorkflowGroupExternal[] groups,
        DateTime? startedDate)
    {
        Id = id;
        Type = type;
        Status = status;
        Groups = groups;
        StartedDate = startedDate;
    }

    public string Id { get; }
    public EntitiesApprovalWorkflowStageTypeExternal Type { get; }
    public EntitiesApprovalWorkflowStageStatusExternal Status { get; }
    public EntitiesApprovalWorkflowGroupExternal[] Groups { get; }
    public DateTime? StartedDate { get; }

    public bool IsCompleted => Status != EntitiesApprovalWorkflowStageStatusExternal.NotStarted && Status != EntitiesApprovalWorkflowStageStatusExternal.InProgress;
}
