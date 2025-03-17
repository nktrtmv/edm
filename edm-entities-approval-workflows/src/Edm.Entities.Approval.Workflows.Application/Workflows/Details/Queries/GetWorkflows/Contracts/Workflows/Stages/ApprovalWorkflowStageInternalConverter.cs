using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups;
using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows.Stages.Statuses;
using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows.Stages.Types;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows.Stages;

internal static class ApprovalWorkflowStageInternalConverter
{
    internal static ApprovalWorkflowStageInternal FromDomain(ApprovalWorkflowStage stage)
    {
        Id<ApprovalWorkflowStageInternal> id = IdConverterFrom<ApprovalWorkflowStageInternal>.From(stage.Id);

        ApprovalWorkflowGroupInternal[] approvers = stage.Groups
            .Select(ApprovalWorkflowGroupInternalConverter.FromDomain)
            .ToArray();

        ApprovalWorkflowStageStatusInternal status = ApprovalWorkflowStageStatusInternalConverter.FromDomain(stage.Status);

        ApprovalWorkflowStageTypeInternal type = ApprovalWorkflowStageTypeInternalConverter.FromDomain(stage.Type);

        UtcDateTime<ApprovalWorkflowStageInternal>? startedDate =
            NullableConverter.Convert(stage.StartedDate, UtcDateTimeConverterFrom<ApprovalWorkflowStageInternal>.From);

        var result = new ApprovalWorkflowStageInternal(id, stage.Name, approvers, status, type, startedDate);

        return result;
    }
}
