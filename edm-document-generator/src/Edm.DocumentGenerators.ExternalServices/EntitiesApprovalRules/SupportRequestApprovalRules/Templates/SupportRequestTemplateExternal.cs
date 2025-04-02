using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Tokens.Concurrency;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.SupportRequestApprovalRules.Templates;

public sealed record SupportRequestTemplateExternal(
    Id<DocumentTemplate> TemplateId,
    string DisplayName,
    string CreatedBy,
    string UpdatedBy,
    DateTime EntityTypeUpdatedDate,
    DateTime EntityTypeCreatedDatetime,
    ConcurrencyToken<DocumentTemplate> ConcurrencyToken,
    int[] ReferenceIds,
    bool IsActive);
