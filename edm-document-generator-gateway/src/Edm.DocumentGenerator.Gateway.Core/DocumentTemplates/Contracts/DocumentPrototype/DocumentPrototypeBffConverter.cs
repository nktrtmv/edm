using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Parameters;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators;
using Edm.DocumentGenerator.Gateway.Core.Documents;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Notifications;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Numbering;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentStatusTransitions;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype;

internal static class DocumentPrototypeBffConverter
{
    public static DocumentPrototypeBff ToBff(
        DocumentPrototypeDto prototype,
        DomainRoles domainRoles)
    {
        DocumentAttributeBff[] attributes = prototype.Attributes
            .Select(x => DocumentAttributeBffFromDtoConverter.FromDto(x, domainRoles))
            .ToArray();
        DocumentStatusTransitionPrototypeBff[] transitions = prototype.StatusesTransitions.Select(DocumentStatusTransitionTemplateBffConverter.ToBff).ToArray();
        DocumentValidatorBff[] validators = prototype.Validators.Select(DocumentValidatorBffConverter.FromBff).ToArray();
        DocumentStatusTransitionPrototypeBff[] statusesTransitions = prototype.StatusesTransitions.Select(DocumentStatusTransitionTemplateBffConverter.ToBff).ToArray();

        DocumentNotificationBff[] notifications = prototype
            .Notifications
            .Select(notification => DocumentNotificationBffConverter.ToBff(notification, statusesTransitions))
            .ToArray();

        var numbering = DocumentNumberingBffConverter.ToBff(prototype.Numbering);

        var parameters = DocumentParametersBffConverter.FromDto(prototype.Parameters);

        var documentPrototypeBff = new DocumentPrototypeBff
        {
            Attributes = attributes,
            StatusesTransitions = transitions,
            Notifications = notifications,
            FrontMetadata = prototype.FrontMetadata,
            Validators = validators,
            Numbering = numbering,
            Parameters = parameters
        };

        return documentPrototypeBff;
    }

    public static DocumentPrototypeDto ToDto(DomainRoles domainRoles, DocumentPrototypeBff source)
    {
        DocumentAttributeDto[] attributes = source.Attributes.Select(x => DocumentAttributeBffToDtoConverter.ToDto(x, domainRoles)).ToArray();
        DocumentStatusTransitionPrototypeDto[] statusesTransitions = source.StatusesTransitions.Select(DocumentStatusTransitionTemplateBffConverter.ToDto).ToArray();
        DocumentValidatorDto[] validators = source.Validators.Select(DocumentValidatorBffConverter.ToDto).ToArray();

        DocumentNotificationDto[] notifications = source
            .Notifications
            .Select(notification => DocumentNotificationBffConverter.ToDto(notification, source.StatusesTransitions))
            .ToArray();

        var numbering = DocumentNumberingBffConverter.ToDto(source.Numbering);

        var parameters = DocumentParametersBffConverter.ToDto(source.Parameters);

        var documentPrototype = new DocumentPrototypeDto
        {
            Attributes = { attributes },
            StatusesTransitions = { statusesTransitions },
            Notifications = { notifications },
            Numbering = numbering,
            FrontMetadata = source.FrontMetadata,
            Validators = { validators },
            Parameters = parameters
        };

        return documentPrototype;
    }
}
