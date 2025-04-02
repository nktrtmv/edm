using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Notifications.Matches;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Notifications.Parameters;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Notifications.Templates;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentStatusTransitions;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Notifications;

internal static class DocumentNotificationBffConverter
{
    public static DocumentNotificationBff ToBff(DocumentNotificationDto notification, DocumentStatusTransitionPrototypeBff[] statusesTransitions)
    {
        var match = DocumentNotificationMatchBffConverter.ToBff(notification.Match, statusesTransitions);
        var template = new DocumentNotificationTemplateSlimBff
        {
            Id = notification.TemplateId
        };

        DocumentNotificationParameterBff[] parameters = notification.Parameters.Select(DocumentNotificationParameterBffConverter.ToBff).ToArray();

        var result = new DocumentNotificationBff
        {
            Id = notification.Id,
            Match = match,
            Template = template,
            Parameters = parameters,
            RecipientId = notification.RecipientAttributeIds.FirstOrDefault(),
            RecipientAttributeIds = notification.RecipientAttributeIds.ToHashSet(),
            RecipientRoles = notification.RecipientRoles.ToHashSet()
        };

        return result;
    }

    public static DocumentNotificationDto ToDto(DocumentNotificationBff notification, DocumentStatusTransitionPrototypeBff[] statusesTransitions)
    {
        var match = DocumentNotificationMatchBffConverter.ToDto(notification.Match, statusesTransitions);

        DocumentNotificationParameterDto[] parameters = notification.Parameters.Select(DocumentNotificationParameterBffConverter.ToDto).ToArray();

        HashSet<string> recipientIds = notification.RecipientAttributeIds.Concat([notification.RecipientId]).Where(x => !string.IsNullOrWhiteSpace(x)).OfType<string>().ToHashSet();
        var result = new DocumentNotificationDto
        {
            Id = notification.Id,
            Match = match,
            TemplateId = notification.Template.Id,
            Parameters = { parameters },
            RecipientAttributeIds = { recipientIds },
            RecipientRoles = { notification.RecipientRoles }
        };

        return result;
    }
}
