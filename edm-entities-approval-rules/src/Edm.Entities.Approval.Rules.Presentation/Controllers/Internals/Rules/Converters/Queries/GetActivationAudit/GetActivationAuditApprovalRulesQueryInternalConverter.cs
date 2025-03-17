using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetActivationAudit.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Converters.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.GetActivationAudit;

internal static class GetActivationAuditApprovalRulesQueryInternalConverter
{
    internal static GetActivationAuditApprovalRulesQueryInternal FromDto(GetActivationAuditApprovalRulesQuery query)
    {
        EntityTypeKeyInternal entityTypeKey = EntityTypeKeyDtoConverter.ToInternal(query.EntityTypeKey);

        var result = new GetActivationAuditApprovalRulesQueryInternal(entityTypeKey);

        return result;
    }
}
