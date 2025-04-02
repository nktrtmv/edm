using Edm.Entities.Approval.Rules.Application.External.Rules.Commands.UpsertEntityType.Contracts.EntitiesTypes;
using Edm.Entities.Approval.Rules.Domain.Entities.Domains.ValueObjects;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;

public sealed record EntityTypeKeyInternal(
    DomainId DomainId,
    Id<EntityTypeInternal> EntityTypeId,
    UtcDateTime<EntityTypeInternal> EntityTypeUpdatedDate);
