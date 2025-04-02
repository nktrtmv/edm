namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Notifications.Parameters;

public sealed class DocumentNotificationParameterBff
{
    public required DocumentNotificationTemplateParameterSlimBff TemplateParameter { get; init; }
    public required string ValueAttributeId { get; init; }
}
