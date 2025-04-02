using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Contracts.Notifications.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Notifications.Parameters;

public sealed class DocumentNotificationParameterInternal
{
    public DocumentNotificationParameterInternal(Id<NotificationTemplateParameterInternal> templateParameterId, Id<DocumentAttributeInternal> valueId)
    {
        TemplateParameterId = templateParameterId;
        ValueId = valueId;
    }

    public Id<NotificationTemplateParameterInternal> TemplateParameterId { get; }
    public Id<DocumentAttributeInternal> ValueId { get; }
}
