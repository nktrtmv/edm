using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentNotifier.Requests.SendNotification.Notifications.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions.Data;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Abstractions.DocumentNotifier.Requests.SendNotification.TemplatesParameters.
    Transitions.Comments;

internal static class DocumentCommentTransitionTemplateParametersFactory
{
    private const string TemplateParameterId = "Comment";

    internal static SendNotificationDocumentNotifierRequestNotificationParameter CreateFrom(string comment)
    {
        var attributeData = DocumentAttributeData.Empty;

        DocumentAttribute attribute = new DocumentStringAttribute([], attributeData);

        var attributeValue = new StringDocumentAttributeValue(attribute, [comment]);

        Id<NotificationTemplateParameter> templateParameterId = IdConverterFrom<NotificationTemplateParameter>.FromString(TemplateParameterId);

        var result = new SendNotificationDocumentNotifierRequestNotificationParameter(templateParameterId, attributeValue);

        return result;
    }
}
