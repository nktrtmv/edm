using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetActivationAudit.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.GetActivationAudit.Audits;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.GetActivationAudit;

internal static class GetActivationAuditApprovalRulesQueryResponseInternalConverter
{
    internal static GetActivationAuditApprovalRulesQueryResponse ToDto(GetActivationAuditApprovalRulesQueryResponseInternal response)
    {
        GetActivationAuditApprovalRulesQueryResponseAuditRecord[] records =
            response.ActivationAudit.Select(ApprovalRuleActivationAuditRecordInternalConverter.ToDto).ToArray();

        var result = new GetActivationAuditApprovalRulesQueryResponse
        {
            ActivationAudit = { records }
        };

        return result;
    }
}
