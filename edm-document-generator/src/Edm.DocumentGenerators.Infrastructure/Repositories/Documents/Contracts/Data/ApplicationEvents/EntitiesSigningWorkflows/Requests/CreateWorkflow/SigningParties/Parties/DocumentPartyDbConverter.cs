using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parties.
    ValueObjects.Parties;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parties.
    ValueObjects.Parties.Types;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesSigningWorkflows.Requests.CreateWorkflow.SigningParties.
    Parties.Types;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesSigningWorkflows.Requests.CreateWorkflow.SigningParties.
    Parties;

internal static class DocumentPartyDbConverter
{
    internal static DocumentPartyDb FromDomain(DocumentParty party)
    {
        var companyId = IdConverterTo.ToString(party.Id);

        DocumentPartyTypeDb type = DocumentPartyTypeDbConverter.FromDomain(party.Type);

        var result = new DocumentPartyDb
        {
            CompanyId = companyId,
            Type = type
        };

        return result;
    }

    internal static DocumentParty ToDomain(DocumentPartyDb party)
    {
        Id<DocumentParty> companyId = IdConverterFrom<DocumentParty>.FromString(party.CompanyId);

        DocumentPartyType type = DocumentPartyTypeDbConverter.ToDomain(party.Type);

        var result = new DocumentParty(companyId, type);

        return result;
    }
}
