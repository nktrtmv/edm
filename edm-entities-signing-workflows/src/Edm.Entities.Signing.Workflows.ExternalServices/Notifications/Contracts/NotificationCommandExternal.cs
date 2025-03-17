using Edm.Entities.Signing.Workflows.ExternalServices.Notifications.Contracts.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.ExternalServices.Notifications.Contracts;

public sealed class NotificationCommandExternal
{
    public NotificationCommandExternal(
        Id<NotificationCommandExternal> idempotencyId,
        Id<NotificationTemplateExternal> templateId,
        Dictionary<string, string> templateTags,
        params Id<EmployeeExternal>[] recipientsIds)
    {
        IdempotencyId = idempotencyId;
        TemplateId = templateId;
        TemplateTags = templateTags;
        RecipientsIds = recipientsIds;
    }

    public Id<NotificationCommandExternal> IdempotencyId { get; }
    public Id<NotificationTemplateExternal> TemplateId { get; }
    public Dictionary<string, string> TemplateTags { get; }
    public Id<EmployeeExternal>[] RecipientsIds { get; }
}
