using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Consumers.EntitiesApprovalWorkflows.Results.Converters.WorkflowCompleted;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using MediatR;

namespace Edm.DocumentGenerators.Presentation.Consumers.EntitiesApprovalWorkflows.Results.Converters;

internal static class EntitiesApprovalWorkflowsResultsValueConverter
{
    internal static IRequest ToInternal(EntitiesApprovalWorkflowsResultsValue value)
    {
        IRequest result = value.ResultCase switch
        {
            EntitiesApprovalWorkflowsResultsValue.ResultOneofCase.WorkflowCompleted =>
                WorkflowCompletedEntitiesApprovalWorkflowsResultInternalConverter.FromDto(value.WorkflowCompleted, value.DomainId),

            _ => throw new ArgumentTypeOutOfRangeException(value.ResultCase)
        };

        return result;
    }
}
