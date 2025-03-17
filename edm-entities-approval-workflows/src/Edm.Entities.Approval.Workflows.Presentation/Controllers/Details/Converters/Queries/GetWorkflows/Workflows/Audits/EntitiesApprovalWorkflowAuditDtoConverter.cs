using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Audits;

internal static class EntitiesApprovalWorkflowAuditDtoConverter
{
    internal static EntitiesApprovalWorkflowAuditDto FromInternal(Audit<ApprovalWorkflowInternal> audit)
    {
        var createdAt = UtcDateTimeConverterTo.ToTimeStamp(audit.CreatedAt);

        var updatedAt = UtcDateTimeConverterTo.ToTimeStamp(audit.UpdatedAt);

        var result = new EntitiesApprovalWorkflowAuditDto
        {
            CreatedAt = createdAt,
            UpdatedAt = updatedAt
        };

        return result;
    }
}
