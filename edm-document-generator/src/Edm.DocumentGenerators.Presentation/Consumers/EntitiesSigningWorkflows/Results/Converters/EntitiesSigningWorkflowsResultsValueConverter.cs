using Edm.DocumentGenerators.Application.DocumentsWorkflows.Signing.Results.WorkflowCompleted.Contracts;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Consumers.EntitiesSigningWorkflows.Results.Converters.WorkflowCompleted;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using MediatR;

namespace Edm.DocumentGenerators.Presentation.Consumers.EntitiesSigningWorkflows.Results.Converters;

internal static class EntitiesSigningWorkflowsResultsValueConverter
{
    internal static IRequest ToInternal(EntitiesSigningWorkflowsResultsValue value)
    {
        WorkflowCompletedEntitiesSigningWorkflowsResultInternal? result = value.ResultCase switch
        {
            EntitiesSigningWorkflowsResultsValue.ResultOneofCase.WorkflowCompleted =>
                WorkflowCompletedEntitiesSigningWorkflowResultConverter.ToInternal(value.WorkflowCompleted),

            _ => throw new ArgumentTypeOutOfRangeException(value.ResultCase)
        };

        return result;
    }
}
