using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts;
using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts.Inheritors.WorkflowCompleted;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Publisher.Results.Converters.Values.WorkflowCompleted;

namespace Edm.Entities.Approval.Workflows.Presentation.Publisher.Results.Converters.Values;

internal static class EntitiesApprovalWorkflowsResultsValueConverter
{
    internal static EntitiesApprovalWorkflowsResultsValue FromDomain(EntitiesApprovalWorkflowsResultInternal request)
    {
        var result = request switch
        {
            WorkflowCompletedEntitiesApprovalWorkflowsResultInternal r =>
                WorkflowCompletedEntitiesApprovalWorkflowsResultConverter.FromDomain(r, request.DomainId),

            _ => throw new ArgumentTypeOutOfRangeException(request)
        };

        return result;
    }
}
