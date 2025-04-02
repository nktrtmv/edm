using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Get.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Converters.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.Get;

internal static class GetApprovalRuleQueryInternalConverter
{
    internal static GetApprovalRuleQueryInternal FromDto(GetApprovalRuleQuery query)
    {
        EntityTypeKeyInternal entityTypeKey = EntityTypeKeyDtoConverter.ToInternal(query.EntityTypeKey);

        var result = new GetApprovalRuleQueryInternal(entityTypeKey);

        return result;
    }
}
