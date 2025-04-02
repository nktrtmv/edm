using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Markers;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Audits.Records.Activate;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Application.Records.ValueObjects.Headings;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetActivationAudit.Contracts.Audits.Records.Records.Activate;

internal static class ApprovalRuleActivatedAuditRecordInternalConverter
{
    internal static ApprovalRuleActivatedAuditRecordInternal FromDomain(ApprovalRuleActivatedAuditRecord record)
    {
        AuditRecordHeadingInternal<ApprovalRuleInternal> heading =
            AuditRecordHeadingInternalConverter<ApprovalRuleInternal>.FromDomain(record.Heading);

        var result = new ApprovalRuleActivatedAuditRecordInternal(heading, record.Comment);

        return result;
    }
}
