using Edm.DocumentGenerators.Application.Contracts;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Contracts.Notifications;
using Edm.DocumentGenerators.Application.Contracts.Parameters;
using Edm.DocumentGenerators.Application.Contracts.Validators;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.StatusesTransitions;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Attributes;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Notifications;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Parameters;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.StatusesTransitions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Validators;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Contracts.Prototypes.Numbering;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Contracts.Prototypes;

internal static class DocumentPrototypeDtoConverter
{
    internal static DocumentPrototypeInternal ToInternal(DocumentPrototypeDto prototype)
    {
        DocumentStatusTransitionPrototypeInternal[] statusTransitions =
            prototype.StatusesTransitions.Select(DocumentStatusTransitionPrototypeDtoConverter.ToInternal).ToArray();

        DocumentAttributeInternal[] attributes =
            prototype.Attributes.Select(DocumentAttributeDtoToInternalConverter.ToInternal).ToArray();

        DocumentValidatorInternal[] validators =
            prototype.Validators.Select(DocumentValidatorDtoConverter.ToInternal).ToArray();

        DocumentNotificationInternal[] notifications =
            prototype.Notifications.Select(DocumentNotificationDtoConverter.ToInternal).ToArray();

        DocumentNumberingInternal? numbering = DocumentNumberingDtoConverter.ToInternal(prototype.Numbering);

        Metadata<FrontInternal> frontMetadata = MetadataConverterFrom<FrontInternal>.FromString(prototype.FrontMetadata);

        DocumentParametersInternal? parameters = DocumentParametersDtoConverter.ToInternal(prototype.Parameters);

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

    internal static DocumentPrototypeDto FromInternal(DocumentPrototypeInternal prototype)
    {
        DocumentStatusTransitionPrototypeDto[]? statusTransitions =
            prototype.StatusTransitions.Select(DocumentStatusTransitionPrototypeDtoConverter.FromInternal).ToArray();

        DocumentAttributeDto[] attributes =
            prototype.Attributes.Select(DocumentAttributeDtoFromInternalConverter.FromInternal).ToArray();

        DocumentValidatorDto[] validators =
            prototype.Validators.Select(DocumentValidatorDtoConverter.FromInternal).ToArray();

        DocumentNotificationDto[] notifications =
            prototype.Notifications.Select(DocumentNotificationDtoConverter.FromInternal).ToArray();

        DocumentNumberingDto? numbering = DocumentNumberingDtoConverter.FromInternal(prototype.Numbering);

        var frontMetadata = MetadataConverterTo.ToString(prototype.FrontMetadata);

        DocumentParametersDto? parameters = DocumentParametersDtoConverter.FromInternal(prototype.Parameters);

        var result = new DocumentPrototypeDto
        {
            Attributes = { attributes },
            Validators = { validators },
            StatusesTransitions = { statusTransitions },
            Notifications = { notifications },
            Numbering = numbering,
            FrontMetadata = frontMetadata,
            Parameters = parameters
        };

        return result;
    }
}
