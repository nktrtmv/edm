using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts.Inheritors.WorkflowCompleted;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Signing.Workflows.Presentation.Publisher.Producers.SigningWorkflows.Results.Converters.Keys.WorkflowCompleted;

internal static class WorkflowCompletedEntitiesSigningWorkflowsResultsKeyConverter
{
    internal static EntitiesSigningWorkflowsResultsKey FromInternal(WorkflowCompletedEntitiesSigningWorkflowResultInternal message)
    {
        var key = IdConverterTo.ToString(message.EntityId);

        var result = new EntitiesSigningWorkflowsResultsKey
        {
            Key = key
        };

        return result;
    }
}
