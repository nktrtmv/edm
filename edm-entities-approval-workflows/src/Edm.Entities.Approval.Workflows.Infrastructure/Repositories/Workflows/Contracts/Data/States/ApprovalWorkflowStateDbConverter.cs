using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.Factories;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Statuses;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States;

internal static class ApprovalWorkflowStateDbConverter
{
    internal static ApprovalWorkflowStateDb FromDomain(ApprovalWorkflowState state)
    {
        ApprovalWorkflowStageDb[] stages = state.Stages.Select(ApprovalWorkflowStageDbConverter.FromDomain).ToArray();

        ApprovalWorkflowStatusDb status = ApprovalWorkflowStatusDbConverter.FromDomain(state.Status);

        string[] ownersIds = state.OwnersIds.Select(IdConverterTo.ToString).ToArray();

        string? documentAuthorId = NullableConverter.Convert(state.DocumentAuthorId, IdConverterTo.ToString);

        Timestamp? actualizedDate = NullableConverter.Convert(state.ActualizedDate, UtcDateTimeConverterTo.ToTimeStamp);

        var result = new ApprovalWorkflowStateDb
        {
            Stages = { stages },
            Status = status,
            OwnersIds = { ownersIds },
            DocumentAuthorId = documentAuthorId,
            ActualizedDate = actualizedDate,
            IsLocked = state.IsLocked
        };

        return result;
    }

    internal static ApprovalWorkflowState ToDomain(ApprovalWorkflowStateDb state)
    {
        ApprovalWorkflowStage[] stages = state.Stages.Select(ApprovalWorkflowStageDbConverter.ToDomain).ToArray();

        ApprovalWorkflowStatus status = ApprovalWorkflowStatusDbConverter.ToDomain(state.Status);

        Id<Employee>[] ownersIds = state.OwnersIds.Select(IdConverterFrom<Employee>.FromString).ToArray();

        UtcDateTime<ApprovalWorkflowState>? actualizedDate =
            NullableConverter.Convert(state.ActualizedDate, UtcDateTimeConverterFrom<ApprovalWorkflowState>.FromTimestamp);

        Id<Employee>? documentAuthorId =
            NullableConverter.Convert(state.DocumentAuthorId, IdConverterFrom<Employee>.FromString);

        ApprovalWorkflowState result = ApprovalWorkflowStateFactory.CreateFromDb(stages, status, ownersIds, documentAuthorId, actualizedDate, state.IsLocked);

        return result;
    }
}
