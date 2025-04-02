using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts.Inheritors.WorkflowCompleted;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Publisher.Producers.SigningWorkflows.Results.Converters.Values.Results.WorkflowCompleted;

namespace Edm.Entities.Signing.Workflows.Presentation.Publisher.Producers.SigningWorkflows.Results.Converters.Values;

internal static class EntitiesSigningWorkflowsResultsValueConverter
{
    internal static EntitiesSigningWorkflowsResultsValue FromInternal(EntitiesSigningWorkflowsResultInternal message)
    {
        var domainId = IdConverterTo.ToString(message.DomainId);

        EntitiesSigningWorkflowsResultsValue result = message switch
        {
            WorkflowCompletedEntitiesSigningWorkflowResultInternal workflowCompleted =>
                WorkflowCompletedEntitiesSigningWorkflowResultConverter.FromInternal(domainId, workflowCompleted),

            _ => throw new ArgumentTypeOutOfRangeException(message)
        };

        return result;
    }
}
