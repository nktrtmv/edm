using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentNotifier.Requests;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentNotifier.Requests.SendNotification;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.DocumentNotifier.Requests.SendNotification;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.DocumentNotifier.Requests;

internal static class DocumentNotifierRequestDocumentApplicationEventDbConverter
{
    internal static DocumentNotifierRequestDocumentApplicationEventDb FromDomain(DocumentNotifierRequestDocumentApplicationEvent applicationEvent)
    {
        var result = new DocumentNotifierRequestDocumentApplicationEventDb();

        switch (applicationEvent)
        {
            case SendNotificationDocumentNotifierRequestDocumentApplicationEvent e:
                result.AsSendNotification = SendNotificationDocumentNotifierRequestDbConverter.FromDomain(e);

                break;

            default:
                throw new ArgumentTypeOutOfRangeException(applicationEvent);
        }

        return result;
    }

    internal static DocumentNotifierRequestDocumentApplicationEvent ToDomain(DocumentNotifierRequestDocumentApplicationEventDb applicationEvent)
    {
        DocumentNotifierRequestDocumentApplicationEvent result = applicationEvent.RequestCase switch
        {
            DocumentNotifierRequestDocumentApplicationEventDb.RequestOneofCase.AsSendNotification =>
                SendNotificationDocumentNotifierRequestDbConverter.ToDomain(applicationEvent.AsSendNotification),

            _ => throw new ArgumentTypeOutOfRangeException(applicationEvent)
        };

        return result;
    }
}
