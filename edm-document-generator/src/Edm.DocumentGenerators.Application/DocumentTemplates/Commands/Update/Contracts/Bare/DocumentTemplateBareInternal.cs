using Edm.DocumentGenerators.Application.Contracts;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Tokens.Concurrency;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Commands.Update.Contracts.Bare;

public sealed record DocumentTemplateBareInternal(
    string DomainId,
    string Id,
    string Name,
    string? SystemName,
    DocumentTemplateStatus Status,
    DocumentPrototypeInternal DocumentPrototype,
    Metadata<FrontInternal> FrontMetadata,
    ConcurrencyToken<DocumentTemplateBareInternal> ConcurrencyToken);
