using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts.Inheritors.WorkflowCompleted;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Publisher.Results.Converters.Values.WorkflowCompleted.States;

namespace Edm.Entities.Approval.Workflows.Presentation.Publisher.Results.Converters.Values.WorkflowCompleted;

internal static class WorkflowCompletedEntitiesApprovalWorkflowsResultConverter
{
    internal static EntitiesApprovalWorkflowsResultsValue FromDomain(
        WorkflowCompletedEntitiesApprovalWorkflowsResultInternal request,
        string domainId)
    {
        var workflowId = IdConverterTo.ToString(request.WorkflowId);

        WorkflowCompletedEntitiesApprovalWorkflowsResultState state =
            WorkflowCompletedEntitiesApprovalWorkflowsResultStateConverter.FromDomain(request.Status);

        var completedByUserId = IdConverterTo.ToString(request.CompletedByUserId);

        var asWorkflowCompleted = new WorkflowCompletedEntitiesApprovalWorkflowsResult
        {
            EntityId = request.EntityId,
            WorkflowId = workflowId,
            State = state,
            CompletedByUserId = completedByUserId,
            CompletionComment = request.CompletionComment
        };

        var result = new EntitiesApprovalWorkflowsResultsValue
        {
            DomainId = domainId,
            WorkflowCompleted = asWorkflowCompleted
        };

        return result;
    }
}
