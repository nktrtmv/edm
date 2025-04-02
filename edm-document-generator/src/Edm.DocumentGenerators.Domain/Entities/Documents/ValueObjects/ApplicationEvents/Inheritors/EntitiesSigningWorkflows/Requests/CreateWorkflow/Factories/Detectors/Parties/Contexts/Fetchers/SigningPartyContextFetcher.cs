using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters.Inheritors.ByRoles.Inheritors.References;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parties.
    ValueObjects.Parties;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.DocumentsRoles;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.Factories.Detectors.
    Parties.Contexts.Fetchers;

internal static class SigningPartyContextFetcher
{
    internal static SigningPartyContext? Fetch(
        DocumentAttributesValuesFetcher fetcher,
        DocumentAttributeDocumentRole role,
        string referenceType)
    {
        var selector = new DocumentReferenceAttributeValueSelector(
            role,
            referenceType);

        string[]? values = fetcher.FetchSingleAttributeOrNullWithAllValues(selector);

        string? partyIdString = values.FirstOrDefault();

        if (partyIdString is null)
        {
            return null;
        }

        Id<DocumentParty> partyId = IdConverterFrom<DocumentParty>.FromString(partyIdString);

        var result = new SigningPartyContext(partyId);

        return result;
    }
}
