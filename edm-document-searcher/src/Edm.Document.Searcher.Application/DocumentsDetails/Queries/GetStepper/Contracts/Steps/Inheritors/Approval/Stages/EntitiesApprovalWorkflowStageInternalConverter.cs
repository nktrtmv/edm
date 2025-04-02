using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Groups;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Statuses;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Enrichment.Contexts;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages;

internal static class EntitiesApprovalWorkflowStageInternalConverter
{
    internal static EntitiesApprovalWorkflowStageInternal[] FromExternal(
        EntitiesApprovalWorkflowExternal workflow,
        DocumentConversionContext conversionContext)
    {
        var result = new List<EntitiesApprovalWorkflowStageInternal>();

        var index = 1;

        foreach (var stageExternal in workflow.Stages)
        {
            var status =
                EntitiesApprovalWorkflowStageStatusInternalConverter.FromExternal(stageExternal.Status);

            EntitiesApprovalWorkflowGroupInternal[] groups =
                stageExternal.Groups.Select(a => EntitiesApprovalWorkflowGroupInternalConverter.FromExternal(a, stageExternal, workflow, conversionContext))
                    .ToArray();

            var stage = new EntitiesApprovalWorkflowStageInternal
            {
                Id = stageExternal.Id.Value,
                Number = index,
                Status = status,
                Groups = groups,
                StartedDate = stageExternal.StartedDate?.Value
            };

            result.Add(stage);

            index++;
        }

        return result.ToArray();
    }
}
