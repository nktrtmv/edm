using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Contexts;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Args;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Args.ValueObjects.Changes;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.AttributesValues.AttributeValueChanged;

public sealed record DocumentAttributeValueChangedEventArgs(DocumentEventContext Context, EventChange<DocumentAttributeValue> Change)
    : DocumentEventArgs<DocumentEventContext>(Context);
