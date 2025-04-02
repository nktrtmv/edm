using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.Factories.Detectors.
    Options;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.Factories.Detectors.
    Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.ValueObjects.Options;
using
    Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.Factories;

internal static class CreateWorkflowEntitiesApprovalWorkflowsRequestDocumentApplicationEventFactory
{
    internal static CreateWorkflowEntitiesApprovalWorkflowsRequestDocumentApplicationEvent Create(Document document, Id<User> currentUserId)
    {
        DocumentApprovalParameters parameters = DocumentApprovalParametersDetector.Detect(document);

        DocumentApprovalOptions options = DocumentApprovalOptionsDetector.Detect(document);

        var result = new CreateWorkflowEntitiesApprovalWorkflowsRequestDocumentApplicationEvent(parameters, options, currentUserId);

        return result;
    }
}
