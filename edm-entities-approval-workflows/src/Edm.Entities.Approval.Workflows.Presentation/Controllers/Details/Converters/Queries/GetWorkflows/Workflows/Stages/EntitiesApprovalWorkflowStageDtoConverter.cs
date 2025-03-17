using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Statuses;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Types;

using Google.Protobuf.WellKnownTypes;

using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows.Stages;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Stages;

internal static class EntitiesApprovalWorkflowStageDtoConverter
{
    internal static EntitiesApprovalWorkflowStageDto FromInternal(ApprovalWorkflowStageInternal stage)
    {
        var id = IdConverterTo.ToString(stage.Id);

        EntitiesApprovalWorkflowStageTypeDto type = EntitiesApprovalWorkflowStageTypeDtoConverter.FromInternal(stage.Type);

        EntitiesApprovalWorkflowStageStatusDto status = EntitiesApprovalWorkflowStageStatusDtoConverter.FromInternal(stage.Status);

        EntitiesApprovalWorkflowGroupDto[] groups = stage.Groups.Select(EntitiesApprovalWorkflowGroupDtoConverter.FromInternal).ToArray();

        Timestamp? startedDate = NullableConverter.Convert(stage.StartedDate, UtcDateTimeConverterTo.ToTimeStamp);

        var result = new EntitiesApprovalWorkflowStageDto
        {
            Id = id,
            Type = type,
            Groups = { groups },
            Status = status,
            StartedDate = startedDate,
            Name = stage.Name
        };

        return result;
    }
}
