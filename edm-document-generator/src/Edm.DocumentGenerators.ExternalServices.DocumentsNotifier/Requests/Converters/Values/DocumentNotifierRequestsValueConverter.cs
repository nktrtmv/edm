using Edm.DocumentGenerators.ExternalServices.DocumentsNotifier.Requests.Contracts;
using Edm.DocumentGenerators.ExternalServices.DocumentsNotifier.Requests.Contracts.Inheritors.SendNotification;
using Edm.DocumentGenerators.ExternalServices.DocumentsNotifier.Requests.Converters.Values.SendNotification;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.Documents.Notifiers.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.DocumentsNotifier.Requests.Converters.Values;

internal static class DocumentNotifierRequestsValueConverter
{
    internal static DocumentNotifyCommand FromExternal(DocumentNotifierRequestExternal request)
    {
        if (request is not SendNotificationDocumentNotifierRequestExternal sendNotification)
        {
            throw new UnsupportedTypeArgumentException<SendNotificationDocumentNotifierRequestExternal>(request);
        }

        DocumentNotifyCommand result = SendNotificationDocumentNotifierRequestConverter.FromExternal(sendNotification);

        return result;
    }
}
