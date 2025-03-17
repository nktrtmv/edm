using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Services.DocumentAutorChangedDetector;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.AttributesValues.AttributeValueChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.UpdateDocumentAuthor;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Handlers;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Inheritors.DocumentAttributeValueChanged.EntitiesApprovalWorkflows.Requests.
    UpdateDocumentAuthor;

internal sealed class UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestDocumentAttributeValueChangedDocumentEventsHandler
    : EventsHandlerGeneric<DocumentAttributeValueChangedEventArgs>
{
    public override void Handle(DocumentAttributeValueChangedEventArgs args)
    {
        Id<User>? authorIdTo = DocumentAuthorChangedDetector.GetChangedOrNull(args.Change, args.Context);

        if (authorIdTo is null)
        {
            return;
        }

        TryUpdateDocumentAuthor(args.Context.Host, authorIdTo);
    }

    private static void TryUpdateDocumentAuthor(Document document, Id<User> authorId)
    {
        DocumentApprovalWorkflow? workflow = document.ApprovalData.Workflows.LastOrDefault();

        if (workflow?.Status != DocumentApprovalWorkflowStatus.InProgress)
        {
            return;
        }

        var updateDocumentAuthor = new UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestDocumentApplicationEvent(authorId);

        document.ApplicationEvents.Add(updateDocumentAuthor);
    }
}
