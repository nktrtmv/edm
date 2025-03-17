using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetVersions.Contracts;

internal static class GetVersionsApprovalRulesQueryBffConverter
{
    internal static GetVersionsApprovalRulesQuery ToDto(GetVersionsApprovalRulesQueryBff source)
    {
        var entityTypeKey = EntityTypeKeyBffConverter.ToDto(source.EntityTypeKey);

        var result = new GetVersionsApprovalRulesQuery
        {
            EntityTypeKey = entityTypeKey
        };

        return result;
    }
}
