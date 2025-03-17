using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Helpers.Attributes;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Helpers.Statuses.Validators;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches.AttributeValueChanged;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches.StatusChanged;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Parameters;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.Notifications;

internal sealed class DocumentNotificationsValidator
{
    private DocumentNotificationsValidator(
        DocumentAttributeExistsValidator attributeExistsValidator,
        DocumentStatusTransitionExistsValidator statusTransitionExistsValidator)
    {
        AttributeExistsValidator = attributeExistsValidator;
        StatusTransitionExistsValidator = statusTransitionExistsValidator;
    }

    private DocumentAttributeExistsValidator AttributeExistsValidator { get; }
    private DocumentStatusTransitionExistsValidator StatusTransitionExistsValidator { get; }

    internal static void Validate(
        DocumentNotification[] notifications,
        DocumentAttributeExistsValidator attributeExistsValidator,
        DocumentStatusTransitionExistsValidator statusTransitionExistsValidator)
    {
        var validator = new DocumentNotificationsValidator(attributeExistsValidator, statusTransitionExistsValidator);

        validator.Validate(notifications);
    }

    private void Validate(DocumentNotification[] notifications)
    {
        foreach (DocumentNotification notification in notifications)
        {
            ValidateMatch(notification.Match);

            ValidateTemplateParameters(notification.Parameters);

            foreach (Id<DocumentAttribute> notificationRecipientId in notification.RecipientAttributeIds)
            {
                ValidateRecipient(notificationRecipientId);
            }
        }
    }

    private void ValidateMatch(DocumentNotificationMatch match)
    {
        bool _ = match switch
        {
            DocumentAttributeValueChangedNotificationMatch m =>
                AttributeExistsValidator.Validate(m.AttributeId),

            DocumentStatusChangedNotificationMatch m =>
                StatusTransitionExistsValidator.Validate(m.StatusFromId, m.StatusToId),

            _ => throw new ArgumentTypeOutOfRangeException(match)
        };
    }

    private void ValidateTemplateParameters(DocumentNotificationParameter[] parameters)
    {
        foreach (DocumentNotificationParameter parameter in parameters)
        {
            AttributeExistsValidator.Validate(parameter.ValueId);
        }
    }

    private void ValidateRecipient(Id<DocumentAttribute> recipientId)
    {
        AttributeExistsValidator.Validate(recipientId);
    }
}
