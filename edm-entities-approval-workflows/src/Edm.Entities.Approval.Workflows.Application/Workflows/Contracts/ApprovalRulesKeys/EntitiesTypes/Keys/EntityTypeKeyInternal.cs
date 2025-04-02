using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.ApprovalRulesKeys.EntitiesTypes.Keys.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.ApprovalRulesKeys.EntitiesTypes.Keys;

public sealed record EntityTypeKeyInternal(
    string DomainId,
    Id<EntityTypeInternal> EntityTypeId,
    UtcDateTime<EntityTypeInternal> EntityTypeUpdatedDate);
