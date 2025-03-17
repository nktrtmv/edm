using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Statuses;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups;

public sealed class EntitiesApprovalWorkflowGroupExternal
{
    public EntitiesApprovalWorkflowGroupExternal(
        string id,
        string name,
        EntitiesApprovalWorkflowAssignmentExternal[] assignments,
        EntitiesApprovalWorkflowGroupStatusExternal status)
    {
        Id = id;
        Name = name;
        Assignments = assignments;
        Status = status;
    }

    public string Id { get; }
    public string Name { get; }
    public EntitiesApprovalWorkflowAssignmentExternal[] Assignments { get; }
    public EntitiesApprovalWorkflowGroupStatusExternal Status { get; }
}
