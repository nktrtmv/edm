using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Detectors.StatusParameters.ReferenceAttributes;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.Statuses.StatusChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Handlers;
using Edm.DocumentGenerators.GenericSubdomain.Extensions.Types;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Inheritors.DocumentStatusChanged.Attributes.SetCurrentUsers;

internal sealed class SetCurrentUserToAttributeDocumentStatusChangedDocumentEventsHandler : EventsHandlerGeneric<DocumentStatusChangedEventArgs>
{
    public static readonly SetCurrentUserToAttributeDocumentStatusChangedDocumentEventsHandler Instance =
        new SetCurrentUserToAttributeDocumentStatusChangedDocumentEventsHandler();

    public override void Handle(DocumentStatusChangedEventArgs args)
    {
        Id<DocumentAttribute>? setCurrentUserToAttribute =
            ReferenceAttributeStatusParameterDetector.GetValueOrNull(args.Change.Transition.To, DocumentStatusParameterKind.SetCurrentUserToAttribute);

        if (setCurrentUserToAttribute is null)
        {
            return;
        }

        DocumentAttributeValue attributeValue = args.Context.Host.AttributesValues.Single(v => v.Id == setCurrentUserToAttribute);

        ReferenceDocumentAttributeValue referenceAttribute = TypeCasterTo<ReferenceDocumentAttributeValue>.CastRequired(attributeValue);

        var currentUserIdString = IdConverterTo.ToString(args.Context.ActorId);

        referenceAttribute.SetValues([currentUserIdString]);
    }
}
