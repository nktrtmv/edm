namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Notifications.Matches.Inheritors;

public sealed class DocumentStatusChangedNotificationMatchBff : DocumentNotificationMatchBff
{
    public required string TransitionId { get; init; }
}
