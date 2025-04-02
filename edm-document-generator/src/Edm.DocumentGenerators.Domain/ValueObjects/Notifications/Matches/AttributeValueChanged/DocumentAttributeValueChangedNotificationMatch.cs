using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.AttributesValues.AttributeValueChanged;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Notifications.Matches.AttributeValueChanged;

public sealed class DocumentAttributeValueChangedNotificationMatch : DocumentNotificationMatchGeneric<DocumentAttributeValueChangedEventArgs>
{
    public DocumentAttributeValueChangedNotificationMatch(Id<DocumentAttribute> attributeId)
    {
        AttributeId = attributeId;
    }

    public Id<DocumentAttribute> AttributeId { get; }

    public override bool IsMatched(DocumentAttributeValueChangedEventArgs args)
    {
        bool result = args.Change.From.Id == AttributeId;

        return result;
    }
}
