using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Contracts.Notifications.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Parameters;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Notifications.Parameters;

internal static class DocumentNotificationParameterInternalConverter
{
    internal static DocumentNotificationParameterInternal FromDomain(DocumentNotificationParameter parameter)
    {
        Id<NotificationTemplateParameterInternal> id = IdConverterFrom<NotificationTemplateParameterInternal>.From(parameter.TemplateParameterId);

        Id<DocumentAttributeInternal> valueId = IdConverterFrom<DocumentAttributeInternal>.From(parameter.ValueId);

        var result = new DocumentNotificationParameterInternal(id, valueId);

        return result;
    }

    internal static DocumentNotificationParameter ToDomain(DocumentNotificationParameterInternal parameter)
    {
        Id<NotificationTemplateParameter> templateParameterId = IdConverterFrom<NotificationTemplateParameter>.From(parameter.TemplateParameterId);

        Id<DocumentAttribute> valueId = IdConverterFrom<DocumentAttribute>.From(parameter.ValueId);

        var result = new DocumentNotificationParameter(templateParameterId, valueId);

        return result;
    }
}
