using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.Presentation.Abstractions;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps.Stages.Groups;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps.Stages.Statuses;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps.Stages;

internal static class EntitiesApprovalWorkflowStageConverter
{
    internal static EntitiesApprovalWorkflowStageDto FromInternal(EntitiesApprovalWorkflowStageInternal stage)
    {
        var status = EntitiesApprovalWorkflowStageStatusConverter.FromInternal(stage.Status);
        var groups = stage.Groups.Select(EntitiesApprovalWorkflowGroupConverter.FromInternal);
        var startedDate = NullableConverter.Convert(stage.StartedDate, Timestamp.FromDateTime);

        var result = new EntitiesApprovalWorkflowStageDto
        {
            Id = stage.Id,
            Number = stage.Number,
            Status = status,
            StartedDate = startedDate,
            Groups = { groups }
        };

        return result;
    }
}
