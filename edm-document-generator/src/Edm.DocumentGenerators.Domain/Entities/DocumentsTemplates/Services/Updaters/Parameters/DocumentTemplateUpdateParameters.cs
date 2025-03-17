using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Parameters;

public sealed record DocumentTemplateUpdateParameters(
    DocumentTemplate Template,
    DocumentAttribute[] OriginalAttributes,
    Dictionary<Id<DocumentAttribute>, DocumentAttribute> OriginalAttributesById,
    DocumentTemplateName UpdatedName,
    SystemName? UpdatedSystemName,
    DocumentTemplateStatus UpdatedStatus,
    DocumentPrototype UpdatedPrototype,
    DocumentAttribute[] UpdatedAttributes,
    Metadata<Front> UpdatedFrontMetadata,
    Id<User> CurrentUserId);
