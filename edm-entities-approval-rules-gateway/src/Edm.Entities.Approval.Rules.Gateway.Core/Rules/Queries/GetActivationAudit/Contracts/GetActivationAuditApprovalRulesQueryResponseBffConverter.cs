using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetActivationAudit.Contracts.Audits.Records;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetActivationAudit.Contracts;

internal static class GetActivationAuditApprovalRulesQueryResponseBffConverter
{
    internal static GetActivationAuditApprovalRulesQueryResponseBff FromDto(GetActivationAuditApprovalRulesQueryResponse response, EnrichersContext context)
    {
        GetActivationAuditApprovalRulesQueryResponseAuditRecordBff[] activationAudit =
            response.ActivationAudit.Select(r => ApprovalRuleAuditRecordBffConverter.FromDto(r, context)).ToArray();

        var result = new GetActivationAuditApprovalRulesQueryResponseBff
        {
            ActivationAudit = activationAudit
        };

        return result;
    }
}
