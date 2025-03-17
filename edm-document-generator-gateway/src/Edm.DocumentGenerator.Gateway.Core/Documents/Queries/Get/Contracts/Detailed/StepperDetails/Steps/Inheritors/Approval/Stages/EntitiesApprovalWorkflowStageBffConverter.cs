using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Groups;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Statuses;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages;

internal static class EntitiesApprovalWorkflowStageBffConverter
{
    public static EntitiesApprovalWorkflowStageBff[] FromExternal(
        EntitiesApprovalWorkflowExternal workflow,
        DocumentConversionContext conversionContext)
    {
        var result = new List<EntitiesApprovalWorkflowStageBff>();

        var index = 1;

        foreach (var stageExternal in workflow.Stages)
        {
            var status =
                EntitiesApprovalWorkflowStageStatusBffConverter.FromExternal(stageExternal.Status);

            EntitiesApprovalWorkflowGroupBff[] groups =
                stageExternal.Groups.Select(a => EntitiesApprovalWorkflowGroupBffConverter.FromExternal(a, conversionContext)).ToArray();

            var stage = new EntitiesApprovalWorkflowStageBff
            {
                Id = stageExternal.Id,
                Number = index,
                Status = status,
                Groups = groups,
                StartedDate = stageExternal.StartedDate
            };

            result.Add(stage);

            index++;
        }

        return result.ToArray();
    }
}
