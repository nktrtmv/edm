using Edm.DocumentGenerators.Application.Contracts;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Contracts.Notifications;
using Edm.DocumentGenerators.Application.Contracts.Parameters;
using Edm.DocumentGenerators.Application.Contracts.Validators;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.StatusesTransitions;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Factories;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering;
using Edm.DocumentGenerators.Domain.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications;
using Edm.DocumentGenerators.Domain.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes;

internal static class DocumentPrototypeInternalConverter
{
    internal static DocumentPrototypeInternal FromDomain(DocumentPrototype prototype, DocumentTemplate template)
    {
        DocumentStatusTransitionPrototypeInternal[]? statusTransitions =
            prototype.StatusTransitions.Select(t => DocumentStatusTransitionPrototypeInternalConverter.FromDomain(t, template))
                .ToArray();

        DocumentAttributeInternal[]? attributes =
            prototype.Attributes.Select(DocumentAttributeInternalFromDomainConverter.FromDomain)
                .ToArray();

        DocumentValidatorInternal[]? validators =
            prototype.Validators.Select(DocumentValidatorInternalConverter.FromDomain)
                .ToArray();

        DocumentNotificationInternal[] notifications =
            prototype.Notifications.Select(DocumentNotificationInternalConverter.FromDomain)
                .ToArray();

        DocumentNumberingInternal? numbering = DocumentNumberingInternalConverter.FromDomain(prototype.Numbering);

        Metadata<FrontInternal> frontMetadata = MetadataConverterFrom<FrontInternal>.From(prototype.FrontMetadata);

        DocumentParametersInternal? parameters = DocumentParametersInternalConverter.FromDomain(prototype.Parameters);

        var result = new DocumentPrototypeInternal(
            statusTransitions,
            attributes,
            validators,
            notifications,
            numbering,
            frontMetadata,
            parameters);

        return result;
    }

    internal static DocumentPrototype ToDomain(DocumentPrototypeInternal prototype)
    {
        DocumentStatusTransition[]? statusTransitions =
            prototype.StatusTransitions.Select(DocumentStatusTransitionPrototypeInternalConverter.ToDomain).ToArray();

        DocumentAttribute[]? attributes =
            prototype.Attributes.Select(DocumentAttributeInternalToDomainConverter.ToDomain).ToArray();

        DocumentValidator[]? validators =
            prototype.Validators.Select(DocumentValidatorInternalConverter.ToDomain).ToArray();

        DocumentNotification[] notifications =
            prototype.Notifications.Select(DocumentNotificationInternalConverter.ToDomain).ToArray();

        DocumentNumbering? numbering = DocumentNumberingInternalConverter.ToDomain(prototype.Numbering);

        Metadata<Front> frontMetadata = MetadataConverterFrom<Front>.From(prototype.FrontMetadata);

        DocumentParameters? parameters = DocumentParametersInternalConverter.ToDomain(prototype.Parameters);

        DocumentPrototype? result = DocumentPrototypeFactory.CreateFrom(
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
