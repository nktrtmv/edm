namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Notifications.Matches.Inheritors;

public sealed class DocumentAttributeValueChangedNotificationMatchBff : DocumentNotificationMatchBff
{
    public required string AttributeId { get; init; }
}
