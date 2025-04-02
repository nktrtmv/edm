using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Services.ClerkChangedDetector;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.AttributesValues.AttributeValueChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.UpdateOwners;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Handlers;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Inheritors.DocumentAttributeValueChanged.EntitiesApprovalWorkflows.Requests.
    UpdateOwners;

internal sealed class UpdateOwnersEntitiesApprovalWorkflowsRequestDocumentAttributeValueChangedDocumentEventsHandler
    : EventsHandlerGeneric<DocumentAttributeValueChangedEventArgs>
{
    public override void Handle(DocumentAttributeValueChangedEventArgs args)
    {
        Id<User>? clerkIdTo = DocumentClerkChangedDetector.GetChangedOrNull(args.Change);

        if (clerkIdTo is null)
        {
            return;
        }

        TryUpdateOwners(args.Context.Host, clerkIdTo);
    }

    private static void TryUpdateOwners(Document document, Id<User> clerkId)
    {
        DocumentApprovalWorkflow? workflow = document.ApprovalData.Workflows.LastOrDefault();

        if (workflow?.Status != DocumentApprovalWorkflowStatus.InProgress)
        {
            return;
        }

        var updateOwners = new UpdateOwnersEntitiesApprovalWorkflowsRequestDocumentApplicationEvent(clerkId);

        document.ApplicationEvents.Add(updateOwners);
    }
}
