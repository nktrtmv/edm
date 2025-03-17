using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parties.
    ValueObjects.Parties.Types;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesSigningWorkflows.Requests.CreateWorkflow.SigningParties.
    Parties.Types;

internal static class DocumentPartyTypeDbConverter
{
    internal static DocumentPartyTypeDb FromDomain(DocumentPartyType type)
    {
        DocumentPartyTypeDb result = type switch
        {
            DocumentPartyType.Self => DocumentPartyTypeDb.Self,
            DocumentPartyType.Contractor => DocumentPartyTypeDb.Contractor,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static DocumentPartyType ToDomain(DocumentPartyTypeDb type)
    {
        DocumentPartyType result = type switch
        {
            DocumentPartyTypeDb.Self => DocumentPartyType.Self,
            DocumentPartyTypeDb.Contractor => DocumentPartyType.Contractor,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
