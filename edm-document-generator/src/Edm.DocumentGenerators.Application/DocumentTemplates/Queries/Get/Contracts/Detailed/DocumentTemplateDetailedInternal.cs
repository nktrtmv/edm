using Edm.DocumentGenerators.Application.Contracts;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits;
using Edm.DocumentGenerators.GenericSubdomain.Tokens.Concurrency;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Queries.Get.Contracts.Detailed;

public sealed record DocumentTemplateDetailedInternal(
    string DomainId,
    string Id,
    string Name,
    string? SystemName,
    DocumentTemplateStatus Status,
    DocumentPrototypeInternal DocumentPrototype,
    UtcDateTime<DocumentTemplate>? ApprovalAttributesVersion,
    Metadata<FrontInternal> FrontMetadata,
    AuditInternal<DocumentTemplateDetailedInternal> Audit,
    ConcurrencyToken<DocumentTemplateDetailedInternal> ConcurrencyToken);
