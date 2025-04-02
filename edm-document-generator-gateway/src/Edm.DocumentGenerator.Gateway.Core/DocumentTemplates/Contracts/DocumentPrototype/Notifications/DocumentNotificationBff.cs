using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Notifications.Matches;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Notifications.Parameters;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Notifications.Templates;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Notifications;

public sealed class DocumentNotificationBff
{
    public required string Id { get; init; }
    public required DocumentNotificationMatchBff Match { get; init; }
    public required DocumentNotificationTemplateSlimBff Template { get; init; }
    public required DocumentNotificationParameterBff[] Parameters { get; init; }
    public string? RecipientId { get; init; }

    public HashSet<string> RecipientAttributeIds { get; init; } = [];

    public HashSet<string> RecipientRoles { get; init; } = [];
}
