using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Parameters;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Notifications.Parameters;

internal static class DocumentNotificationParameterDbConverter
{
    internal static DocumentNotificationParameterDb FromDomain(DocumentNotificationParameter parameter)
    {
        var templateParameterId = IdConverterTo.ToString(parameter.TemplateParameterId);

        var valueAttributeId = IdConverterTo.ToString(parameter.ValueId);

        var result = new DocumentNotificationParameterDb
        {
            TemplateParameterId = templateParameterId,
            ValueAttributeId = valueAttributeId
        };

        return result;
    }

    internal static DocumentNotificationParameter ToDomain(DocumentNotificationParameterDb parameter)
    {
        // TODO: REMOVE: This is for backward compatability (Number and NumberContract shall be mapped to DocumentNumber).

        // < START

        string originalTemplateParameterId = parameter.TemplateParameterId;

        string mappedTemplateParameterId = originalTemplateParameterId is "NumberContract" or "Number"
            ? "DocumentNumber"
            : originalTemplateParameterId;

        // < END

        Id<NotificationTemplateParameter> templateParameterId = IdConverterFrom<NotificationTemplateParameter>.FromString(mappedTemplateParameterId);

        Id<DocumentAttribute> valueId = IdConverterFrom<DocumentAttribute>.FromString(parameter.ValueAttributeId);

        var result = new DocumentNotificationParameter(templateParameterId, valueId);

        return result;
    }
}
