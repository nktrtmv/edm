using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.ApprovalRulesKeys.EntitiesTypes.Keys;
using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.ApprovalRulesKeys.EntitiesTypes.Keys.Markers;

namespace Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Parameters.ApprovalRulesKeys.EntitiesTypes.
    Keys;

internal static class ExternalEntityTypeKeyDtoConverter
{
    internal static EntityTypeKeyInternal ToInternal(EntityTypeKeyDto entityTypeKey)
    {
        Id<EntityTypeInternal> entityTypeId = IdConverterFrom<EntityTypeInternal>.FromString(entityTypeKey.EntityTypeId);

        UtcDateTime<EntityTypeInternal> entityTypeUpdatedDate = UtcDateTimeConverterFrom<EntityTypeInternal>.FromTimestamp(entityTypeKey.EntityTypeUpdatedDate);

        var result = new EntityTypeKeyInternal(entityTypeKey.DomainId, entityTypeId, entityTypeUpdatedDate);

        return result;
    }
}
