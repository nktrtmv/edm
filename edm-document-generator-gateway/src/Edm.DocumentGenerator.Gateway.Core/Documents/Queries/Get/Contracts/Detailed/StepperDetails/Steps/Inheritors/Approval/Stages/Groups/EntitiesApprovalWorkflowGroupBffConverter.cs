using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Groups.Statuses;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Groups;

internal static class EntitiesApprovalWorkflowGroupBffConverter
{
    public static EntitiesApprovalWorkflowGroupBff FromExternal(EntitiesApprovalWorkflowGroupExternal group, DocumentConversionContext conversionContext)
    {
        EntitiesApprovalWorkflowAssignmentBff[] assignments = EntitiesApprovalWorkflowAssignmentBffConverter.FromExternal(group.Assignments, conversionContext);

        var status = EntitiesApprovalWorkflowGroupStatusBffConverter.FromExternal(group.Status);

        var result = new EntitiesApprovalWorkflowGroupBff
        {
            Id = group.Id,
            Name = group.Name,
            Assignments = assignments,
            Status = status
        };

        return result;
    }
}
