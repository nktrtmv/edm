using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentStatusTransitions;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Notifications.Matches.Inheritors;

internal static class DocumentStatusChangedNotificationMatchBffConverter
{
    public static DocumentStatusChangedNotificationMatchBff ToBff(
        DocumentStatusChangedNotificationMatchDto match,
        DocumentStatusTransitionPrototypeBff[] statusesTransitions)
    {
        var transition = statusesTransitions.Single(x => x.From.Id == match.StatusFromId && x.To.Id == match.StatusToId);

        var result = new DocumentStatusChangedNotificationMatchBff
        {
            TransitionId = transition.Id
        };

        return result;
    }

    public static DocumentNotificationMatchDto StatusChangeToDto(
        DocumentStatusChangedNotificationMatchBff match,
        DocumentStatusTransitionPrototypeBff[] statusesTransitions)
    {
        var transition = statusesTransitions.Single(x => x.Id == match.TransitionId);

        var statusFromId = transition.From.Id;
        var statusToId = transition.To.Id;

        var asStatusChanged = new DocumentStatusChangedNotificationMatchDto
        {
            StatusFromId = statusFromId,
            StatusToId = statusToId
        };

        var result = new DocumentNotificationMatchDto
        {
            AsStatusChanged = asStatusChanged
        };

        return result;
    }
}
