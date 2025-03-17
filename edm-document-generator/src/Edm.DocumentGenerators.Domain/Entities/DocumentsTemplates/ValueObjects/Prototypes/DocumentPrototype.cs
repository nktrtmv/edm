using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering;
using Edm.DocumentGenerators.Domain.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications;
using Edm.DocumentGenerators.Domain.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes;

public sealed record DocumentPrototype(
    DocumentStatusTransition[] StatusTransitions,
    DocumentAttribute[] Attributes,
    DocumentValidator[] Validators,
    DocumentNotification[] Notifications,
    DocumentNumbering Numbering,
    Metadata<Front> FrontMetadata,
    DocumentParameters Parameters);
