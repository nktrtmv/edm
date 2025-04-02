using Edm.DocumentGenerators.Application.Contracts.Notifications.Matches;
using Edm.DocumentGenerators.Application.Contracts.Notifications.Matches.AttributeValueChanged;
using Edm.DocumentGenerators.Application.Contracts.Notifications.Matches.StatusChanged;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Notifications.Matches.AttributeValueChanged;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Notifications.Matches.StatusChanged;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Notifications.Matches;

internal static class DocumentNotificationMatchDtoConverter
{
    internal static DocumentNotificationMatchDto FromInternal(DocumentNotificationMatchInternal match)
    {
        DocumentNotificationMatchDto result = match switch
        {
            DocumentAttributeValueChangedNotificationMatchInternal m =>
                DocumentAttributeValueChangedNotificationMatchDtoConverter.FromInternal(m),

            DocumentStatusChangedNotificationMatchInternal m =>
                DocumentStatusChangedNotificationMatchDtoConverter.FromInternal(m),

            _ => throw new ArgumentTypeOutOfRangeException(match)
        };

        return result;
    }

    internal static DocumentNotificationMatchInternal ToInternal(DocumentNotificationMatchDto match)
    {
        DocumentNotificationMatchInternal result = match.ValueCase switch
        {
            DocumentNotificationMatchDto.ValueOneofCase.AsAttributeValueChanged =>
                DocumentAttributeValueChangedNotificationMatchDtoConverter.ToInternal(match.AsAttributeValueChanged),

            DocumentNotificationMatchDto.ValueOneofCase.AsStatusChanged =>
                DocumentStatusChangedNotificationMatchDtoConverter.ToInternal(match.AsStatusChanged),

            _ => throw new ArgumentTypeOutOfRangeException(match)
        };

        return result;
    }
}
