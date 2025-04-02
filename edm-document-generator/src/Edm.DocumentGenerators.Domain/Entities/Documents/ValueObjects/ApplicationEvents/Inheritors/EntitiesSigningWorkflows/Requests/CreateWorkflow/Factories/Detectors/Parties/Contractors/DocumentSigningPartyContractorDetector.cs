using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.Factories.Detectors.
    Parties.Contexts;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.Factories.Detectors.
    Parties.Contexts.Fetchers;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parties;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parties.
    ValueObjects.Parties;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parties.
    ValueObjects.Parties.Types;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Constants;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.DocumentsRoles;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.Factories.Detectors.
    Parties.Contractors;

internal static class DocumentSigningPartyContractorDetector
{
    internal static DocumentSigningParty Detect(string domainId, IRoleAdapter roleAdapter, DocumentAttributesValuesFetcher fetcher, Id<User> executorId)
    {
        SigningPartyContext? partyContext = GetContractorContext(fetcher);

        if (partyContext is null)
        {
            string? roleDisplay = roleAdapter.GetDocumentRoleDisplayById(domainId, (int)DocumentAttributeDocumentRole.SigningPartyContractor);

            throw new BusinessLogicApplicationException($"There shall be single attribute (role: {roleDisplay}, type:{DocumentAttributeReferenceTypes.Contractors}).");
        }

        var party = new DocumentParty(partyContext.PartyId, DocumentPartyType.Contractor);

        var result = new DocumentSigningParty(party, executorId);

        return result;
    }

    private static SigningPartyContext? GetContractorContext(DocumentAttributesValuesFetcher fetcher)
    {
        SigningPartyContext? result = SigningPartyContextFetcher.Fetch(
            fetcher,
            DocumentAttributeDocumentRole.SigningPartyContractor,
            DocumentAttributeReferenceTypes.Contractors);

        return result;
    }
}
