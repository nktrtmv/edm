using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Entities.Types.Keys;

public sealed record EntitiesApprovalRuleEntityTypeKeyExternal(Id<DocumentTemplate> EntityTypeId, DomainId DomainId, UtcDateTime<DocumentTemplate> EntityTypeVersion);
