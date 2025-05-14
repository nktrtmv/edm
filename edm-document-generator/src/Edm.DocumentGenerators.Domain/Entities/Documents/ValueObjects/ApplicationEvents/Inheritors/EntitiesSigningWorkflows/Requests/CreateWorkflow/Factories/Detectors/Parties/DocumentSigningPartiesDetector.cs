using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters.Inheritors.ByRoles.Inheritors.References;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.Factories.Detectors.
    Parties.Contractors;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.Factories.Detectors.
    Parties.Self;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parties;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Constants;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.DocumentsRoles;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.Factories.Detectors.
    Parties;

internal static class DocumentSigningPartiesDetector
{
    internal static DocumentSigningParty[] Detect(string domainId, IRoleAdapter roleAdapter, DocumentAttributesValuesFetcher fetcher, bool isPaperSigningType)
    {
        Id<User> contractorExecutorId = GetClerkId(fetcher);

        Id<User> selfExecutorId = isPaperSigningType
            ? contractorExecutorId
            : GetSignatoryId(fetcher);

        DocumentSigningParty? self = DocumentSigningPartySelfDetector.Detect(domainId, roleAdapter, fetcher, selfExecutorId);

        DocumentSigningParty? contractor = DocumentSigningPartyContractorDetector.Detect(domainId, roleAdapter, fetcher, contractorExecutorId);

        DocumentSigningParty[] result = { self, contractor };

        return result;
    }

    private static Id<User> GetClerkId(DocumentAttributesValuesFetcher fetcher)
    {
        var selector = new DocumentReferenceAttributeValueSelector(
            DocumentAttributeDocumentRole.DocumentClerk,
            DocumentAttributeReferenceTypes.Employees);

        string? clerkId = fetcher.FetchSingleAttributeWithSingleValue(selector);

        Id<User> result = IdConverterFrom<User>.FromString(clerkId);

        return result;
    }

    private static Id<User> GetSignatoryId(DocumentAttributesValuesFetcher fetcher)
    {
        var selector = new DocumentReferenceAttributeValueSelector(
            DocumentAttributeDocumentRole.SigningSignatory,
            DocumentAttributeReferenceTypes.Employees,
            "ФИО подписанта компании");

        string? signatoryId = fetcher.FetchSingleAttributeWithSingleValue(selector);

        Id<User> result = IdConverterFrom<User>.FromString(signatoryId);

        return result;
    }
}
