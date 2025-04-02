using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Services.AttributeValuesExtractor;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentNotifier.Requests.SendNotification.Notifications.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Parameters;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Abstractions.DocumentNotifier.Requests.SendNotification.TemplatesParameters.
    Attributes;

internal static class DocumentAttributeNotifyTemplateParametersFactory
{
    internal static SendNotificationDocumentNotifierRequestNotificationParameter[] CreateFrom(
        DocumentNotificationParameter[] parameters,
        DocumentsAttributesValuesExtractor extractor)
    {
        SendNotificationDocumentNotifierRequestNotificationParameter[] result = parameters
            .Select(p => CreateParameter(p, extractor))
            .ToArray();

        return result;
    }

    private static SendNotificationDocumentNotifierRequestNotificationParameter CreateParameter(
        DocumentNotificationParameter parameter,
        DocumentsAttributesValuesExtractor extractor)
    {
        DocumentAttributeValue attributeValue = extractor.GetRequiredAttributeValue(parameter.ValueId);

        var result = new SendNotificationDocumentNotifierRequestNotificationParameter(parameter.TemplateParameterId, attributeValue);

        return result;
    }
}
