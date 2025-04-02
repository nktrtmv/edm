using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentNotifier.Requests.SendNotification;
using Edm.DocumentGenerators.ExternalServices.DocumentsNotifier.Requests.Contracts.Inheritors.SendNotification;

namespace Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.DocumentNotifier.Requests.SendNotification.Converters;

internal static class SendNotificationDocumentNotifierRequestExternalConverter
{
    internal static SendNotificationDocumentNotifierRequestExternal FromDomain(
        SendNotificationDocumentNotifierRequestDocumentApplicationEvent applicationEvent,
        Document document)
    {
        var result = new SendNotificationDocumentNotifierRequestExternal(
            document,
            applicationEvent.Notification,
            applicationEvent.CurrentUserId,
            applicationEvent.RecipientIds,
            applicationEvent.RecipientRoles);

        return result;
    }
}
