using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Contexts;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Abstractions.DocumentNotifier.Requests.SendNotification.TemplatesParameters.Attributes;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Abstractions.DocumentNotifier.Requests.SendNotification.TemplatesParameters.Transitions;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Services.AttributeValuesExtractor;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentNotifier.Requests.SendNotification;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentNotifier.Requests.SendNotification.Notifications;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentNotifier.Requests.SendNotification.Notifications.Parameters;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Parameters;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Args;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Handlers;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Abstractions.DocumentNotifier.Requests.SendNotification;

internal abstract class SendNotificationDocumentNotifierRequestDocumentEventsHandler<TEventArgs> : EventsHandlerGeneric<TEventArgs>
    where TEventArgs : DocumentEventArgs<DocumentEventContext>
{
    internal SendNotificationDocumentNotifierRequestDocumentEventsHandler(
        DocumentNotificationMatchGeneric<TEventArgs> match,
        DocumentNotification notification)
    {
        Match = match;
        TemplateId = notification.TemplateId;
        Parameters = notification.Parameters;
        RecipientIds = notification.RecipientAttributeIds;
        RecipientRoles = notification.RecipientRoles;
    }

    private DocumentNotificationMatchGeneric<TEventArgs> Match { get; }
    private Id<NotificationTemplate> TemplateId { get; }
    private DocumentNotificationParameter[] Parameters { get; }
    public HashSet<Id<DocumentAttribute>> RecipientIds { get; set; }
    public HashSet<Role> RecipientRoles { get; set; }

    public override void Handle(TEventArgs args)
    {
        if (!Match.IsMatched(args))
        {
            return;
        }

        Document document = args.Context.Host;

        var extractor = new DocumentsAttributesValuesExtractor(document);

        HashSet<Id<User>> recipientsIds = RecipientIds.SelectMany(extractor.GetRecipientsIds).ToHashSet();

        TryAddApplicationEvent(document, args, extractor, recipientsIds, RecipientRoles);
    }

    private void TryAddApplicationEvent(
        Document document,
        TEventArgs args,
        DocumentsAttributesValuesExtractor extractor,
        HashSet<Id<User>> recipientIds,
        HashSet<Role> recipientRoles)
    {
        Id<User> currentUserId = args.Context.ActorId;

        recipientIds.Remove(currentUserId);

        SendNotificationDocumentNotifierRequestNotificationParameter[] attributeParameters =
            DocumentAttributeNotifyTemplateParametersFactory.CreateFrom(Parameters, extractor);

        SendNotificationDocumentNotifierRequestNotificationParameter[] transitionParameters =
            DocumentTransitionTemplateParametersFactory.CreateFrom(args);

        SendNotificationDocumentNotifierRequestNotificationParameter[] parameters =
            attributeParameters.Concat(transitionParameters).ToArray();

        var notification = new SendNotificationDocumentNotifierRequestNotification(TemplateId, parameters);

        var applicationEvent = new SendNotificationDocumentNotifierRequestDocumentApplicationEvent(notification, currentUserId, recipientIds, recipientRoles);

        document.ApplicationEvents.Add(applicationEvent);
    }
}
