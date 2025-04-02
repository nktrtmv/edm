using Edm.Entities.Signing.Workflows.ExternalServices.Notifications.Contracts;

namespace Edm.Entities.Signing.Workflows.ExternalServices.Notifications;

public interface INotificationClient
{
    Task Send(NotificationCommandExternal command, CancellationToken cancellationToken);
}
