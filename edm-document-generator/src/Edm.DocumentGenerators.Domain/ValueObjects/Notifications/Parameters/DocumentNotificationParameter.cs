using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Parameters;

public sealed class DocumentNotificationParameter
{
    public DocumentNotificationParameter(Id<NotificationTemplateParameter> templateParameterId, Id<DocumentAttribute> valueId)
    {
        TemplateParameterId = templateParameterId;
        ValueId = valueId;
    }

    public Id<NotificationTemplateParameter> TemplateParameterId { get; }
    public Id<DocumentAttribute> ValueId { get; }
}
