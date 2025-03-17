using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Services.ResponsibleManagerChangedDetector;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.AttributesValues.AttributeValueChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.UpdateResponsibleManagers;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Handlers;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Inheritors.DocumentAttributeValueChanged.EntitiesSigningWorkflows.Requests.
    UpdateResponsibleManagers;

internal sealed class UpdateUpdateResponsibleManagerEntitiesSigningWorkflowsRequestDocumentAttributeValueChangedDocumentEventsHandler
    : EventsHandlerGeneric<DocumentAttributeValueChangedEventArgs>
{
    public override void Handle(DocumentAttributeValueChangedEventArgs args)
    {
        Id<User>? responsibleManagerIdTo = DocumentResponsibleManagerChangedDetector.GetChangedOrNull(args.Change);

        if (responsibleManagerIdTo is null)
        {
            return;
        }

        TryUpdateResponsibleManager(args.Context.Host, responsibleManagerIdTo);
    }

    private static void TryUpdateResponsibleManager(Document document, Id<User> responsibleManagerIdTo)
    {
        DocumentSigningWorkflow? workflow = document.SigningData.Workflows.LastOrDefault();

        if (workflow?.Status != DocumentSigningWorkflowStatus.InProgress)
        {
            return;
        }

        var updateResponsibleManager = new UpdateResponsibleManagerEntitiesSigningWorkflowsRequestDocumentApplicationEvent(responsibleManagerIdTo);

        document.ApplicationEvents.Add(updateResponsibleManager);
    }
}
