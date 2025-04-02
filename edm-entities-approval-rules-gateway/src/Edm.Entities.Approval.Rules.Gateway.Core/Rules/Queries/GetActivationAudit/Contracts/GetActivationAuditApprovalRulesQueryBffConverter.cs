using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetActivationAudit.Contracts;

internal static class GetActivationAuditApprovalRulesQueryBffConverter
{
    internal static GetActivationAuditApprovalRulesQuery ToDto(GetActivationAuditApprovalRulesQueryBff query)
    {
        var entityTypeKey = EntityTypeKeyBffConverter.ToDto(query.EntityTypeKey);

        var result = new GetActivationAuditApprovalRulesQuery
        {
            EntityTypeKey = entityTypeKey
        };

        return result;
    }
}
