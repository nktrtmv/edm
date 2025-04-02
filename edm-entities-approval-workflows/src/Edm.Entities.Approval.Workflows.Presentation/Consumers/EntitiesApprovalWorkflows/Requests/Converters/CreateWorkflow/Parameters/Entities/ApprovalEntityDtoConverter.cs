using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Entities;

namespace Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Parameters.Entities;

internal static class ApprovalEntityDtoConverter
{
    internal static ApprovalEntityInternal ToInternal(ApprovalEntityDto entity)
    {
        var result = new ApprovalEntityInternal(entity.Id, entity.DomainId);

        return result;
    }
}
