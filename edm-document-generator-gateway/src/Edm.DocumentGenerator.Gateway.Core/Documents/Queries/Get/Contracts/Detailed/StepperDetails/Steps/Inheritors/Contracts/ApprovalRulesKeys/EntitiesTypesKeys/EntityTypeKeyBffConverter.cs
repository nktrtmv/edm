using Edm.DocumentGenerator.Gateway.ExternalServices.Contracts.ApprovalRulesKeys.EntitiesTypesKeys;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Contracts.ApprovalRulesKeys.EntitiesTypesKeys;

internal static class EntityTypeKeyBffConverter
{
    internal static EntityTypeKeyBff FromExternal(EntityTypeKeyExternal entityTypeKey)
    {
        var result = new EntityTypeKeyBff
        {
            DomainId = entityTypeKey.DomainId,
            EntityTypeId = entityTypeKey.EntityTypeId,
            EntityTypeUpdatedDate = entityTypeKey.EntityTypeUpdatedDate
        };

        return result;
    }
}
