using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches.AttributeValueChanged;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Notifications.Matches.AttributeValueChanged;

internal static class DocumentAttributeValueChangedNotificationMatchDbConverter
{
    internal static DocumentNotificationMatchDb FromDomain(DocumentAttributeValueChangedNotificationMatch match)
    {
        var attributeId = IdConverterTo.ToString(match.AttributeId);

        var result = new DocumentNotificationMatchDb
        {
            AsAttributeValueChanged = new DocumentAttributeValueChangedNotificationMatchDb
            {
                AttributeId = attributeId
            }
        };

        return result;
    }

    internal static DocumentNotificationMatch ToDomain(DocumentAttributeValueChangedNotificationMatchDb match)
    {
        Id<DocumentAttribute> attributeId = IdConverterFrom<DocumentAttribute>.FromString(match.AttributeId);

        var result = new DocumentAttributeValueChangedNotificationMatch(attributeId);

        return result;
    }
}
