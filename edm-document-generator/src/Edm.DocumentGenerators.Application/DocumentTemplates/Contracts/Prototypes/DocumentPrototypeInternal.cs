using Edm.DocumentGenerators.Application.Contracts;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Contracts.Notifications;
using Edm.DocumentGenerators.Application.Contracts.Parameters;
using Edm.DocumentGenerators.Application.Contracts.Validators;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.StatusesTransitions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes;

public sealed record DocumentPrototypeInternal(
    DocumentStatusTransitionPrototypeInternal[] StatusTransitions,
    DocumentAttributeInternal[] Attributes,
    DocumentValidatorInternal[] Validators,
    DocumentNotificationInternal[] Notifications,
    DocumentNumberingInternal Numbering,
    Metadata<FrontInternal> FrontMetadata,
    DocumentParametersInternal Parameters);
