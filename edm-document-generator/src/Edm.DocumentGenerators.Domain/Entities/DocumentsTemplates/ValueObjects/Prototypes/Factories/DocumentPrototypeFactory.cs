using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.Factories;
using Edm.DocumentGenerators.Domain.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications;
using Edm.DocumentGenerators.Domain.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Parameters.Factories;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.Factories;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Factories;

public static class DocumentPrototypeFactory
{
    public static DocumentPrototype CreateNew()
    {
        DocumentStatusTransition[] statusTransitions = DocumentStatusTransitionFactory.CreateDefaultTransitions();

        DocumentAttribute[] attributes = Array.Empty<DocumentAttribute>();

        DocumentValidator[] validators = Array.Empty<DocumentValidator>();

        DocumentNotification[] notifications = Array.Empty<DocumentNotification>();

        DocumentNumbering numbering = DocumentNumberingFactory.CreateNew();

        var frontMetadata = Metadata<Front>.Empty;

        DocumentParameters parameters = DocumentParametersFactory.CreateNew();

        var result = new DocumentPrototype(
            statusTransitions,
            attributes,
            validators,
            notifications,
            numbering,
            frontMetadata,
            parameters);

        return result;
    }

    public static DocumentPrototype CreateFrom(
        DocumentStatusTransition[] statusTransitions,
        DocumentAttribute[] attributes,
        DocumentValidator[] validators,
        DocumentNotification[] notifications,
        DocumentNumbering numbering,
        Metadata<Front> frontMetadata,
        DocumentParameters parameters)
    {
        var result = new DocumentPrototype(
            statusTransitions,
            attributes,
            validators,
            notifications,
            numbering,
            frontMetadata,
            parameters);

        return result;
    }
}
