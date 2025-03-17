using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Notifications.Matches.Inheritors;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentStatusTransitions;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Notifications.Matches;

internal static class DocumentNotificationMatchBffConverter
{
    public static DocumentNotificationMatchBff ToBff(DocumentNotificationMatchDto match, DocumentStatusTransitionPrototypeBff[] statusesTransitions)
    {
        DocumentNotificationMatchBff result = match.ValueCase switch
        {
            DocumentNotificationMatchDto.ValueOneofCase.AsAttributeValueChanged => DocumentAttributeValueChangedNotificationMatchBffConverter.ToBff(
                match.AsAttributeValueChanged),

            DocumentNotificationMatchDto.ValueOneofCase.AsStatusChanged => DocumentStatusChangedNotificationMatchBffConverter.ToBff(
                match.AsStatusChanged,
                statusesTransitions),

            _ => throw new ArgumentTypeOutOfRangeException(match)
        };

        return result;
    }

    public static DocumentNotificationMatchDto ToDto(DocumentNotificationMatchBff match, DocumentStatusTransitionPrototypeBff[] statusesTransitions)
    {
        var result = match switch
        {
            DocumentAttributeValueChangedNotificationMatchBff x => DocumentAttributeValueChangedNotificationMatchBffConverter.AttributeValueChangeToDto(x),
            DocumentStatusChangedNotificationMatchBff x => DocumentStatusChangedNotificationMatchBffConverter.StatusChangeToDto(x, statusesTransitions),
            _ => throw new ArgumentTypeOutOfRangeException(match)
        };

        return result;
    }
}
