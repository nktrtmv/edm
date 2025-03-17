using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Get.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Converters.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.Get;

internal static class GetApprovalRuleQueryResponseInternalConverter
{
    internal static GetApprovalRuleQueryResponse ToDto(GetApprovalRuleQueryResponseInternal response)
    {
        EntityTypeKeyDto key = EntityTypeKeyDtoConverter.FromInternal(response.EntityTypeKey);

        var result = new GetApprovalRuleQueryResponse
        {
            EntityTypeKey = key,
            DisplayName = response.DisplayName,
            IsReadonly = response.IsReadonly
        };

        return result;
    }
}
