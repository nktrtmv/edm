using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parameters.
    Electronics;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesSigningWorkflows.Requests.CreateWorkflow.Parameters.
    Electronics;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesSigningWorkflows.Requests.CreateWorkflow.
    Parameters;

internal static class CreateWorkflowEntitiesSigningWorkflowsRequestParametersDbConverter
{
    internal static CreateWorkflowEntitiesSigningWorkflowsRequestParametersDb FromDomain(DocumentSigningParameters parameters)
    {
        string? documentClerkId = NullableConverter.Convert(parameters.DocumentClerkId, IdConverterTo.ToString);

        CreateWorkflowEntitiesSigningWorkflowsRequestElectronicParametersDb? electronic =
            NullableConverter.Convert(parameters.Electronic, CreateWorkflowEntitiesSigningWorkflowsRequestElectronicParametersDbConverter.FromDomain);

        var result = new CreateWorkflowEntitiesSigningWorkflowsRequestParametersDb
        {
            DocumentClerkId = documentClerkId,
            Electronic = electronic
        };

        return result;
    }

    internal static DocumentSigningParameters ToDomain(CreateWorkflowEntitiesSigningWorkflowsRequestParametersDb parameters)
    {
        Id<User>? documentClerkId = NullableConverter.Convert(parameters.DocumentClerkId, IdConverterFrom<User>.FromString);

        DocumentSigningElectronicParameters? electronic =
            NullableConverter.Convert(parameters.Electronic, CreateWorkflowEntitiesSigningWorkflowsRequestElectronicParametersDbConverter.ToDomain);

        var result = new DocumentSigningParameters(documentClerkId, electronic);

        return result;
    }
}
