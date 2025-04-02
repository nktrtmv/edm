using Edm.DocumentGenerators.ExternalServices.DocumentsNotifier.Requests.Contracts.Inheritors.SendNotification;
using Edm.DocumentGenerators.ExternalServices.DocumentsNotifier.Requests.Converters.Values.SendNotification.Notifications;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.Documents.Notifiers.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.DocumentsNotifier.Requests.Converters.Values.SendNotification;

internal static class SendNotificationDocumentNotifierRequestConverter
{
    internal static DocumentNotifyCommand FromExternal(SendNotificationDocumentNotifierRequestExternal request)
    {
        string domainId = request.Document.DomainId.Value;

        var documentId = IdConverterTo.ToString(request.Document.Id);

        DocumentNotificationDto notification = DocumentNotificationDtoConverter.FromDomain(request.Notification);

        var currentUserId = IdConverterTo.ToString(request.CurrentUserId);

        var result = new DocumentNotifyCommand
        {
            DomainId = domainId,
            RequestId = Guid.NewGuid().ToString(),
            DocumentId = documentId,
            Notification = notification,
            CurrentUserId = currentUserId,
            RecipientIds = { request.RecipientIds.Select(x => x.ToString()) },
            RecipientRoles = { request.RecipientRoles.Select(x => x.Value.ToString()) }
        };

        return result;
    }
}
