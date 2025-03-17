using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Entities.Types.Keys;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;

using Google.Protobuf.WellKnownTypes;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Contracts.EntityTypeKeys;

internal static class EntitiesApprovalRuleEntityTypeKeyDtoConverter
{
    internal static EntityTypeKeyDto FromExternal(EntitiesApprovalRuleEntityTypeKeyExternal key)
    {
        var entityTypeId = IdConverterTo.ToString(key.EntityTypeId);

        Timestamp entityTypeVersion = UtcDateTimeConverterTo.ToTimeStamp(key.EntityTypeVersion);

        var result = new EntityTypeKeyDto
        {
            DomainId = key.DomainId.Value,
            EntityTypeId = entityTypeId,
            EntityTypeUpdatedDate = entityTypeVersion
        };

        return result;
    }
}
