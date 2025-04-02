using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Groups;
using Edm.Document.Searcher.Presentation.Abstractions;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps.Stages.Groups.Assignments;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps.Stages.Groups.Statuses;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps.Stages.Groups;

internal static class EntitiesApprovalWorkflowGroupConverter
{
    internal static EntitiesApprovalWorkflowGroupDto FromInternal(EntitiesApprovalWorkflowGroupInternal group)
    {
        var status = EntitiesApprovalWorkflowGroupStatusConverter.FromInternal(group.Status);
        var assignments = group.Assignments.Select(EntitiesApprovalWorkflowAssignmentConverter.FromInternal);

        var result = new EntitiesApprovalWorkflowGroupDto
        {
            Id = group.Id,
            Name = group.Name,
            Status = status,
            Assignments = { assignments }
        };

        return result;
    }
}
