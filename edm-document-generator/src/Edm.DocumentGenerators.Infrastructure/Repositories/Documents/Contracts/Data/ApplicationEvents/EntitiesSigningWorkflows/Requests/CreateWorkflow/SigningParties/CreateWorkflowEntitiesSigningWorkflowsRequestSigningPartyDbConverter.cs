using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parties;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parties.
    ValueObjects.Parties;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesSigningWorkflows.Requests.CreateWorkflow.SigningParties.
    Parties;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesSigningWorkflows.Requests.CreateWorkflow.SigningParties;

internal static class CreateWorkflowEntitiesSigningWorkflowsRequestSigningPartyDbConverter
{
    internal static CreateWorkflowEntitiesSigningWorkflowsRequestSigningPartyDb FromDomain(DocumentSigningParty signingParty)
    {
        DocumentPartyDb party = DocumentPartyDbConverter.FromDomain(signingParty.Party);

        var executorId = IdConverterTo.ToString(signingParty.ExecutorId);

        var result = new CreateWorkflowEntitiesSigningWorkflowsRequestSigningPartyDb
        {
            Party = party,
            ExecutorId = executorId
        };

        return result;
    }

    internal static DocumentSigningParty ToDomain(CreateWorkflowEntitiesSigningWorkflowsRequestSigningPartyDb signingParty)
    {
        DocumentParty party = DocumentPartyDbConverter.ToDomain(signingParty.Party);

        Id<User> executorId = IdConverterFrom<User>.FromString(signingParty.ExecutorId);

        var result = new DocumentSigningParty(party, executorId);

        return result;
    }
}
