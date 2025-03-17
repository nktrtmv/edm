using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parties;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesSigningWorkflows.Requests.CreateWorkflow.Parameters;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesSigningWorkflows.Requests.CreateWorkflow.SigningParties;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesSigningWorkflows.Requests.CreateWorkflow;

internal static class CreateWorkflowEntitiesSigningWorkflowsRequestDbConverter
{
    internal static CreateWorkflowEntitiesSigningWorkflowsRequestDb FromDomain(CreateWorkflowEntitiesSigningWorkflowsRequestDocumentApplicationEvent request)
    {
        var currentUserId = IdConverterTo.ToString(request.CurrentUserId);

        CreateWorkflowEntitiesSigningWorkflowsRequestParametersDb parameters =
            CreateWorkflowEntitiesSigningWorkflowsRequestParametersDbConverter.FromDomain(request.Parameters);

        CreateWorkflowEntitiesSigningWorkflowsRequestSigningPartyDb[] parties =
            request.Parties.Select(CreateWorkflowEntitiesSigningWorkflowsRequestSigningPartyDbConverter.FromDomain).ToArray();

        var result = new CreateWorkflowEntitiesSigningWorkflowsRequestDb
        {
            CurrentUserId = currentUserId,
            Parameters = parameters,
            Parties = { parties }
        };

        return result;
    }

    internal static CreateWorkflowEntitiesSigningWorkflowsRequestDocumentApplicationEvent ToDomain(CreateWorkflowEntitiesSigningWorkflowsRequestDb request)
    {
        Id<User> currentUserId = IdConverterFrom<User>.FromString(request.CurrentUserId);

        DocumentSigningParameters parameters = request.Parameters is null
            ? CreateWorkflowEntitiesSigningWorkflowsRequestParametersDbConverter.ObsoleteToDomain(request.ElectronicParametersObsolete) // TODO: obsolete remove
            : CreateWorkflowEntitiesSigningWorkflowsRequestParametersDbConverter.ToDomain(request.Parameters);

        DocumentSigningParty[] parties =
            request.Parties.Select(CreateWorkflowEntitiesSigningWorkflowsRequestSigningPartyDbConverter.ToDomain).ToArray();

        var result = new CreateWorkflowEntitiesSigningWorkflowsRequestDocumentApplicationEvent(
            currentUserId,
            parties,
            parameters);

        return result;
    }
}
