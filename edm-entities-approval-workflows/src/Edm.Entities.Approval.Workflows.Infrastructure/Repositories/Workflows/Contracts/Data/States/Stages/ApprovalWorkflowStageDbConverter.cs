using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.Factories;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Types;
using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Statuses;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Types;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages;

internal static class ApprovalWorkflowStageDbConverter
{
    internal static ApprovalWorkflowStageDb FromDomain(ApprovalWorkflowStage stage)
    {
        var id = IdConverterTo.ToString(stage.Id);

        ApprovalWorkflowStageTypeDb type = ApprovalWorkflowStageTypeDbConverter.FromDomain(stage.Type);

        ApprovalWorkflowStageStatusDb status = ApprovalWorkflowStageStatusDbConverter.FromDomain(stage.Status);

        ApprovalWorkflowGroupDb[] groups = stage.Groups.Select(ApprovalWorkflowGroupDbConverter.FromDomain).ToArray();

        Timestamp? startedDate = NullableConverter.Convert(stage.StartedDate, UtcDateTimeConverterTo.ToTimeStamp);

        var result = new ApprovalWorkflowStageDb
        {
            Id = id,
            Type = type,
            Status = status,
            Groups = { groups },
            StartedDate = startedDate
        };

        return result;
    }

    internal static ApprovalWorkflowStage ToDomain(ApprovalWorkflowStageDb stage)
    {
        Id<ApprovalWorkflowStage> id = IdConverterFrom<ApprovalWorkflowStage>.FromString(stage.Id);

        ApprovalWorkflowStageType type = ApprovalWorkflowStageTypeDbConverter.ToDomain(stage.Type);

        ApprovalWorkflowStageStatus status = ApprovalWorkflowStageStatusDbConverter.ToDomain(stage.Status);

        ApprovalWorkflowGroup[] groups = stage.Groups.Select(ApprovalWorkflowGroupDbConverter.ToDomain).ToArray();

        UtcDateTime<ApprovalWorkflowStage>? startedDate =
            NullableConverter.Convert(stage.StartedDate, UtcDateTimeConverterFrom<ApprovalWorkflowStage>.FromTimestamp);

        ApprovalWorkflowStage result = ApprovalWorkflowStageFactory.CreateFromDb(id, stage.Name, type, status, groups, startedDate);

        return result;
    }
}
