using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches.AttributeValueChanged;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches.StatusChanged;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Notifications.Matches.AttributeValueChanged;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Notifications.Matches.StatusChanged;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Notifications.Matches;

internal static class DocumentNotificationMatchDbConverter
{
    internal static DocumentNotificationMatchDb FromDomain(DocumentNotificationMatch match)
    {
        DocumentNotificationMatchDb result = match switch
        {
            DocumentAttributeValueChangedNotificationMatch m =>
                DocumentAttributeValueChangedNotificationMatchDbConverter.FromDomain(m),

            DocumentStatusChangedNotificationMatch m =>
                DocumentStatusChangedNotificationMatchDbConverter.FromDomain(m),

            _ => throw new ArgumentTypeOutOfRangeException(match)
        };

        return result;
    }

    internal static DocumentNotificationMatch ToDomain(DocumentNotificationMatchDb match)
    {
        DocumentNotificationMatch result = match.ValueCase switch
        {
            DocumentNotificationMatchDb.ValueOneofCase.AsAttributeValueChanged =>
                DocumentAttributeValueChangedNotificationMatchDbConverter.ToDomain(match.AsAttributeValueChanged),

            DocumentNotificationMatchDb.ValueOneofCase.AsStatusChanged =>
                DocumentStatusChangedNotificationMatchDbConverter.ToDomain(match.AsStatusChanged),

            _ => throw new ArgumentTypeOutOfRangeException(match)
        };

        return result;
    }
}
