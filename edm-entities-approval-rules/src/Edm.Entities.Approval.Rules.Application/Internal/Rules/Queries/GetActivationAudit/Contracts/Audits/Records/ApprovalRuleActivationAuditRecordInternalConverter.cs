using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Markers;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetActivationAudit.Contracts.Audits.Records.Records.Activate;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetActivationAudit.Contracts.Audits.Records.Records.Deactivate;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Collectors.ActivationAudits.Records;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Audits.Records.Activate;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Audits.Records.Deactivate;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Application.Records;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetActivationAudit.Contracts.Audits.Records;

internal static class ApprovalRuleActivationAuditRecordInternalConverter
{
    internal static ApprovalRuleActivationAuditRecordInternal FromDomain(ApprovalRuleActivationAuditRecord activationAuditRecord)
    {
        AuditRecordInternal<ApprovalRuleInternal> record = activationAuditRecord.Record switch
        {
            ApprovalRuleActivatedAuditRecord activated =>
                ApprovalRuleActivatedAuditRecordInternalConverter.FromDomain(activated),

            ApprovalRuleDeactivatedAuditRecord deactivated =>
                ApprovalRuleDeactivatedAuditRecordInternalConverter.FromDomain(deactivated),

            _ => throw new ArgumentTypeOutOfRangeException(activationAuditRecord)
        };

        var result = new ApprovalRuleActivationAuditRecordInternal(activationAuditRecord.ApprovalRuleVersion, record);

        return result;
    }
}
