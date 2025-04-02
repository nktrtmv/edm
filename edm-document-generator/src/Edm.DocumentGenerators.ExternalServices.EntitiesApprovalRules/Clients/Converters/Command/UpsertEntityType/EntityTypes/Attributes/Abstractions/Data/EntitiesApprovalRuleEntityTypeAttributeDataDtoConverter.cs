using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions.Data;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Command.UpsertEntityType.EntityTypes.Attributes.Abstractions.Data;

internal static class EntitiesApprovalRuleEntityTypeAttributeDataDtoConverter
{
    internal static EntityTypeAttributeDataDto FromExternal(DocumentAttributeData data)
    {
        var result = new EntityTypeAttributeDataDto
        {
            Id = data.ApprovalData.MetadataId,
            DisplayName = data.DisplayName
        };

        return result;
    }
}
