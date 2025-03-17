using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Groups.Statuses;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Enrichment.Contexts;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Groups;

internal static class EntitiesApprovalWorkflowGroupInternalConverter
{
    internal static EntitiesApprovalWorkflowGroupInternal FromExternal(
        EntitiesApprovalWorkflowGroupExternal group,
        EntitiesApprovalWorkflowStageExternal stage,
        EntitiesApprovalWorkflowExternal workflow,
        DocumentConversionContext conversionContext)
    {
        var assignments = EntitiesApprovalWorkflowAssignmentInternalConverter.FromExternal(
            group.Assignments,
            stage,
            workflow,
            conversionContext);

        var status = EntitiesApprovalWorkflowGroupStatusInternalConverter.FromExternal(group.Status);

        var result = new EntitiesApprovalWorkflowGroupInternal
        {
            Id = group.Id,
            Name = group.Name,
            Assignments = assignments,
            Status = status
        };

        return result;
    }
}
