using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetAll.Contracts.Rules.Types;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Converters.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.GetAll.EntityTypes;

internal static class GetAllApprovalRulesQueryResponseEntityTypeInternalConverter
{
    internal static GetAllApprovalRulesQueryResponseEntityTypeDto ToDto(GetAllApprovalRulesQueryResponseEntityTypeInternal entityType)
    {
        EntityTypeKeyDto key = EntityTypeKeyDtoConverter.FromInternal(entityType.Key);

        var result = new GetAllApprovalRulesQueryResponseEntityTypeDto
        {
            Key = key,
            DisplayName = entityType.DisplayName,
            IsActive = entityType.IsActive
        };

        return result;
    }
}
