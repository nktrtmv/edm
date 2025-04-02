using Edm.DocumentGenerators.Application.Contracts.Notifications.Matches.AttributeValueChanged;
using Edm.DocumentGenerators.Application.Contracts.Notifications.Matches.StatusChanged;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches.AttributeValueChanged;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches.StatusChanged;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Application.Contracts.Notifications.Matches;

internal static class DocumentNotificationMatchInternalConverter
{
    internal static DocumentNotificationMatchInternal FromDomain(DocumentNotificationMatch match)
    {
        DocumentNotificationMatchInternal result = match switch
        {
            DocumentAttributeValueChangedNotificationMatch m =>
                DocumentAttributeValueChangedNotificationMatchInternalConverter.FromDomain(m),

            DocumentStatusChangedNotificationMatch m =>
                DocumentStatusChangedNotificationMatchInternalConverter.FromDomain(m),

            _ => throw new ArgumentTypeOutOfRangeException(match)
        };

        return result;
    }

    internal static DocumentNotificationMatch ToDomain(DocumentNotificationMatchInternal match)
    {
        DocumentNotificationMatch result = match switch
        {
            DocumentAttributeValueChangedNotificationMatchInternal m =>
                DocumentAttributeValueChangedNotificationMatchInternalConverter.ToDomain(m),

            DocumentStatusChangedNotificationMatchInternal m =>
                DocumentStatusChangedNotificationMatchInternalConverter.ToDomain(m),

            _ => throw new ArgumentTypeOutOfRangeException(match)
        };

        return result;
    }
}
