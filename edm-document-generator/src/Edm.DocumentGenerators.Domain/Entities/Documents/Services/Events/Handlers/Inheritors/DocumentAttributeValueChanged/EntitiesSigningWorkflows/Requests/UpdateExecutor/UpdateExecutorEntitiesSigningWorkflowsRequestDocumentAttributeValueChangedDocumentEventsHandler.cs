using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Services.ClerkChangedDetector;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.AttributesValues.AttributeValueChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.UpdateExecutor;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Handlers;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Inheritors.DocumentAttributeValueChanged.EntitiesSigningWorkflows.Requests.
    UpdateExecutor;

internal sealed class UpdateExecutorEntitiesSigningWorkflowsRequestDocumentAttributeValueChangedDocumentEventsHandler
    : EventsHandlerGeneric<DocumentAttributeValueChangedEventArgs>
{
    public override void Handle(DocumentAttributeValueChangedEventArgs args)
    {
        Id<User>? clerkIdTo = DocumentClerkChangedDetector.GetChangedOrNull(args.Change);

        if (clerkIdTo is null)
        {
            return;
        }

        TryUpdateExecutor(args.Context.Host, clerkIdTo);
    }

    private static void TryUpdateExecutor(Document document, Id<User> clerkId)
    {
        DocumentSigningWorkflow? workflow = document.SigningData.Workflows.LastOrDefault();

        if (workflow?.Status != DocumentSigningWorkflowStatus.InProgress)
        {
            return;
        }

        var updateExecutor = new UpdateExecutorEntitiesSigningWorkflowsRequestDocumentApplicationEvent(clerkId);

        document.ApplicationEvents.Add(updateExecutor);
    }
}
