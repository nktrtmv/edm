using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts.Inheritors.WorkflowCompleted;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Publisher.Producers.SigningWorkflows.Results.Converters.Keys.WorkflowCompleted;

namespace Edm.Entities.Signing.Workflows.Presentation.Publisher.Producers.SigningWorkflows.Results.Converters.Keys;

internal static class EntitiesSigningWorkflowsResultsKeyConverter
{
    internal static EntitiesSigningWorkflowsResultsKey FromInternal(EntitiesSigningWorkflowsResultInternal message)
    {
        EntitiesSigningWorkflowsResultsKey result = message switch
        {
            WorkflowCompletedEntitiesSigningWorkflowResultInternal workflowCompleted =>
                WorkflowCompletedEntitiesSigningWorkflowsResultsKeyConverter.FromInternal(workflowCompleted),

            _ => throw new ArgumentTypeOutOfRangeException(message)
        };

        return result;
    }
}
