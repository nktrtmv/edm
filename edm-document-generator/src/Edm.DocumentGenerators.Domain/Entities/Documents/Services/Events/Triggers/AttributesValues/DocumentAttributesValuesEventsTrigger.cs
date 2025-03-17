using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Contexts;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.AttributesValues.AttributesValuesChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.AttributesValues.AttributeValueChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.ValueObjects.AttributesChanges;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Args.ValueObjects.Changes;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.AttributesValues;

internal static class DocumentAttributesValuesEventsTrigger
{
    internal static void Trigger(Events<DocumentEventContext> events, DocumentAttributesChange attributesChange)
    {
        EventChange<DocumentAttributeValue>[] changes = DetectChanges(attributesChange).ToArray();

        if (!changes.Any())
        {
            return;
        }

        TriggerEvents(events, changes);
    }

    private static IEnumerable<EventChange<DocumentAttributeValue>> DetectChanges(DocumentAttributesChange attributes)
    {
        Dictionary<Id<DocumentAttribute>, DocumentAttributeValue> originalAttributesValuesById = attributes.OriginalValues.ToDictionary(a => a.Id);

        foreach (DocumentAttributeValue updatedAttributeValue in attributes.UpdatedValues)
        {
            DocumentAttributeValue originalAttributeValue = originalAttributesValuesById[updatedAttributeValue.Id];

            if (originalAttributeValue != updatedAttributeValue)
            {
                var result = new EventChange<DocumentAttributeValue>(originalAttributeValue, updatedAttributeValue);

                yield return result;
            }
        }
    }

    private static void TriggerEvents(Events<DocumentEventContext> events, EventChange<DocumentAttributeValue>[] changes)
    {
        foreach (EventChange<DocumentAttributeValue> change in changes)
        {
            TriggerAttributeValueChangedEvent(events, change);
        }

        TriggerAttributesValuesChangedEvent(events, changes);
    }

    private static void TriggerAttributeValueChangedEvent(Events<DocumentEventContext> events, EventChange<DocumentAttributeValue> change)
    {
        var args = new DocumentAttributeValueChangedEventArgs(events.Context, change);

        events.Trigger(args);
    }

    private static void TriggerAttributesValuesChangedEvent(Events<DocumentEventContext> events, EventChange<DocumentAttributeValue>[] changes)
    {
        var args = new DocumentAttributesValuesChangedEventArgs(events.Context, changes);

        events.Trigger(args);
    }
}
