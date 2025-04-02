using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Contracts.ApprovalRulesKeys.EntitiesTypesKeys;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.ApprovalRulesKeys.
    EntitiesTypesKeys;

internal static class EntityTypeKeyExternalConverter
{
    internal static EntityTypeKeyExternal FromDto(EntityTypeKeyDto entityTypeKey)
    {
        var entityTypeUpdatedDate = entityTypeKey.EntityTypeUpdatedDate.ToDateTime();

        var result = new EntityTypeKeyExternal(entityTypeKey.DomainId, entityTypeKey.EntityTypeId, entityTypeUpdatedDate);

        return result;
    }
}
