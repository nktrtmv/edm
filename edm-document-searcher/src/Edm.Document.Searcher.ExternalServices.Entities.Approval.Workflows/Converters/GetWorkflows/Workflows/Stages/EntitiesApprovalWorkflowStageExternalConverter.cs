using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Statuses;
using Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows.Stages.Groups;
using Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows.Stages.Statuses;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows.Stages;

internal static class EntitiesApprovalWorkflowStageExternalConverter
{
    internal static EntitiesApprovalWorkflowStageExternal FromDto(EntitiesApprovalWorkflowStageDto stage)
    {
        Id<EntitiesApprovalWorkflowStageExternal> id = IdConverterFrom<EntitiesApprovalWorkflowStageExternal>.FromString(stage.Id);

        EntitiesApprovalWorkflowStageStatusExternal status = EntitiesApprovalWorkflowStageStatusExternalConverter.FromDto(stage.Status);

        UtcDateTime<EntitiesApprovalWorkflowStageExternal>? startedDate = NullableConverter.Convert(stage.StartedDate, UtcDateTimeConverterFrom<EntitiesApprovalWorkflowStageExternal>.FromTimestamp);

        EntitiesApprovalWorkflowGroupExternal[] groups = stage.Groups.Select(EntitiesApprovalWorkflowGroupExternalConverter.FromDto).ToArray();

        var result = new EntitiesApprovalWorkflowStageExternal(id, status, startedDate, groups);

        return result;
    }
}
