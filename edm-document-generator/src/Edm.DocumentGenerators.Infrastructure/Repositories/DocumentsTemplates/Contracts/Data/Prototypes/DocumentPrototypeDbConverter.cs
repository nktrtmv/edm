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
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Attributes;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Notifications;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Parameters;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.StatusesTransitions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Validators;
using Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts.Data.Prototypes.Numberings;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts.Data.Prototypes;

internal static class DocumentPrototypeDbConverter
{
    internal static DocumentPrototypeDb FromDomain(DocumentPrototype prototype)
    {
        DocumentStatusTransitionDb[] statusTransitions =
            prototype.StatusTransitions.Select(DocumentStatusTransitionDbConverter.FromDomain).ToArray();

        DocumentAttributeDb[] attributes =
            prototype.Attributes.Select(DocumentAttributeDbFromDomainConverter.FromDomain).ToArray();

        DocumentValidatorDb[] validators =
            prototype.Validators.Select(DocumentValidatorDbConverter.FromDomain).ToArray();

        DocumentNotificationDb[] notifications =
            prototype.Notifications.Select(DocumentNotificationDbConverter.FromDomain).ToArray();

        DocumentNumberingDb numbering = DocumentNumberingDbConverter.FromDomain(prototype.Numbering);

        var frontMetadata = MetadataConverterTo.ToString(prototype.FrontMetadata);

        DocumentParametersDb parameters = DocumentParametersDbConverter.FromDomain(prototype.Parameters);

        var result = new DocumentPrototypeDb
        {
            StatusTransitions = { statusTransitions },
            Attributes = { attributes },
            Validators = { validators },
            Notifications = { notifications },
            Numbering = numbering,
            FrontMetadata = frontMetadata,
            Parameters = parameters
        };

        return result;
    }

    internal static DocumentPrototype ToDomain(DocumentPrototypeDb prototype)
    {
        DocumentStatusTransition[] statusTransitions =
            prototype.StatusTransitions.Select(DocumentStatusTransitionDbConverter.ToDomain).ToArray();

        DocumentAttribute[] attributes =
            prototype.Attributes.Select(DocumentAttributeDbToDomainConverter.ToDomain).ToArray();

        DocumentValidator[] validators =
            prototype.Validators.Select(DocumentValidatorDbConverter.ToDomain).ToArray();

        DocumentNotification[] notifications =
            prototype.Notifications.Select(DocumentNotificationDbConverter.ToDomain).ToArray();

        DocumentNumbering numbering =
            DocumentNumberingDbConverter.ToDomain(prototype.Numbering);

        Metadata<Front> frontMetadata = MetadataConverterFrom<Front>.FromString(prototype.FrontMetadata);

        DocumentParameters parameters = DocumentParametersDbConverter.ToDomain(prototype.Parameters);

        DocumentPrototype result = DocumentPrototypeFactory.CreateFrom(
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
