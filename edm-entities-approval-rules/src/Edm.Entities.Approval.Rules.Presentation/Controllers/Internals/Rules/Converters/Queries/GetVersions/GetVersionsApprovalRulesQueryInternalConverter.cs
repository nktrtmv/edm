using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetVersions.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Converters.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.GetVersions;

internal static class GetVersionsApprovalRulesQueryInternalConverter
{
    internal static GetVersionsApprovalRulesQueryInternal FromDto(GetVersionsApprovalRulesQuery query)
    {
        EntityTypeKeyInternal entityTypeKey = EntityTypeKeyDtoConverter.ToInternal(query.EntityTypeKey);

        var result = new GetVersionsApprovalRulesQueryInternal(entityTypeKey);

        return result;
    }
}
