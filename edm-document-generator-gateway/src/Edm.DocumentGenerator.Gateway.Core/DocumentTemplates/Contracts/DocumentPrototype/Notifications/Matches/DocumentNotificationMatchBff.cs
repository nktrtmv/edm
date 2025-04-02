using System.Text.Json.Serialization;

using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Notifications.Matches.Inheritors;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Notifications.Matches;

[JsonDerivedType(typeof(DocumentAttributeValueChangedNotificationMatchBff), "AttributeValueChanged")]
[JsonDerivedType(typeof(DocumentStatusChangedNotificationMatchBff), "StatusChanged")]
public abstract class DocumentNotificationMatchBff
{
}
