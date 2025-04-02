using
    Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesApprovalWorkflows.Requests.CreateWorkflow.Parameters;

internal static class CreateWorkflowEntitiesApprovalWorkflowsRequestParametersDbConverter
{
    internal static CreateWorkflowEntitiesApprovalWorkflowsRequestParametersDb FromDomain(DocumentApprovalParameters parameters)
    {
        var clerkId = IdConverterTo.ToString(parameters.ClerkId);

        var documentAuthorId = IdConverterTo.ToString(parameters.DocumentAuthorId);

        var result = new CreateWorkflowEntitiesApprovalWorkflowsRequestParametersDb
        {
            Title = parameters.Title,
            Description = parameters.Description,
            ClerkId = clerkId,
            DocumentAuthorId = documentAuthorId
        };

        return result;
    }

    internal static DocumentApprovalParameters ToDomain(CreateWorkflowEntitiesApprovalWorkflowsRequestParametersDb parameters)
    {
        Id<User> clerkId = IdConverterFrom<User>.FromString(parameters.ClerkId);

        Id<User> documentAuthorId = IdConverterFrom<User>.FromString(parameters.DocumentAuthorId);

        var result = new DocumentApprovalParameters(parameters.Title, parameters.Description, clerkId, documentAuthorId);

        return result;
    }
}
