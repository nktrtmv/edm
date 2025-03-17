using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.Factories.Detectors.
    Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.Factories.Detectors.
    Parties;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.Factories.Detectors.
    Types;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.ValueObjects.Parties;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.CreateWorkflow.Factories;

internal static class CreateWorkflowEntitiesSigningWorkflowsRequestDocumentApplicationEventFactory
{
    internal static CreateWorkflowEntitiesSigningWorkflowsRequestDocumentApplicationEvent Create(
        IRoleAdapter roleAdapter,
        Document document,
        Id<User> currentUserId)
    {
        var fetcher = new DocumentAttributesValuesFetcher(document.AttributesValues);

        bool isPaperSigningType = IsDocumentPaperSigningTypeDetector.Detect(fetcher);

        DocumentSigningParameters parameters = DocumentSigningParametersDetector.Detect(fetcher, isPaperSigningType);

        DocumentSigningParty[] parties = DocumentSigningPartiesDetector.Detect(document.DomainId.Value, roleAdapter, fetcher, isPaperSigningType);

        var result = new CreateWorkflowEntitiesSigningWorkflowsRequestDocumentApplicationEvent(currentUserId, parties, parameters);

        return result;
    }
}
