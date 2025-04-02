using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Markers;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Audits.Records.Deactivate;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Application.Records.ValueObjects.Headings;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetActivationAudit.Contracts.Audits.Records.Records.Deactivate;

internal static class ApprovalRuleDeactivatedAuditRecordInternalConverter
{
    internal static ApprovalRuleDeactivatedAuditRecordInternal FromDomain(ApprovalRuleDeactivatedAuditRecord record)
    {
        AuditRecordHeadingInternal<ApprovalRuleInternal> heading =
            AuditRecordHeadingInternalConverter<ApprovalRuleInternal>.FromDomain(record.Heading);

        var result = new ApprovalRuleDeactivatedAuditRecordInternal(heading, record.Comment);

        return result;
    }
}
