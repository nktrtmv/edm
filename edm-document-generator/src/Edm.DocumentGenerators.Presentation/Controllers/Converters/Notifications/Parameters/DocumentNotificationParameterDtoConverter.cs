using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Contracts.Notifications.Markers;
using Edm.DocumentGenerators.Application.Contracts.Notifications.Parameters;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Notifications.Parameters;

internal static class DocumentNotificationParameterDtoConverter
{
    internal static DocumentNotificationParameterDto FromInternal(DocumentNotificationParameterInternal parameter)
    {
        var templateParameterId = IdConverterTo.ToString(parameter.TemplateParameterId);

        var valueAttributeId = IdConverterTo.ToString(parameter.ValueId);

        var result = new DocumentNotificationParameterDto
        {
            TemplateParameterId = templateParameterId,
            ValueAttributeId = valueAttributeId
        };

        return result;
    }

    internal static DocumentNotificationParameterInternal ToInternal(DocumentNotificationParameterDto parameter)
    {
        Id<NotificationTemplateParameterInternal> templateParameterId = IdConverterFrom<NotificationTemplateParameterInternal>.FromString(parameter.TemplateParameterId);

        Id<DocumentAttributeInternal> valueId = IdConverterFrom<DocumentAttributeInternal>.FromString(parameter.ValueAttributeId);

        var result = new DocumentNotificationParameterInternal(templateParameterId, valueId);

        return result;
    }
}
