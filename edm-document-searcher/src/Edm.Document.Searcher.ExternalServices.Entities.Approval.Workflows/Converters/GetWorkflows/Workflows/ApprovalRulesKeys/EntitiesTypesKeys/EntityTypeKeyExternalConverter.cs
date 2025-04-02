using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.ApprovalRulesKeys.EntitiesTypesKeys;
using Edm.Document.Searcher.ExternalServices.Markers;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows.ApprovalRulesKeys.
    EntitiesTypesKeys;

internal static class EntityTypeKeyExternalConverter
{
    internal static EntityTypeKeyExternal FromDto(EntityTypeKeyDto entityTypeKey)
    {
        Id<EntityTypeExternal> typeId = IdConverterFrom<EntityTypeExternal>.FromString(entityTypeKey.EntityTypeId);

        UtcDateTime<EntityTypeExternal> entityTypeUpdatedDate = UtcDateTimeConverterFrom<EntityTypeExternal>.FromTimestamp(entityTypeKey.EntityTypeUpdatedDate);

        var result = new EntityTypeKeyExternal(entityTypeKey.DomainId, typeId, entityTypeUpdatedDate);

        return result;
    }
}
