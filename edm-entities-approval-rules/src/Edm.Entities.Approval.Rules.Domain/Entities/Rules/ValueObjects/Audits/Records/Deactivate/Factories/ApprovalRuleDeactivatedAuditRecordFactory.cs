using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Records.ValueObjects.Headings;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Records.ValueObjects.Headings.Factories;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Audits.Records.Deactivate.Factories;

internal static class ApprovalRuleDeactivatedAuditRecordFactory
{
    internal static ApprovalRuleDeactivatedAuditRecord CreateNew(Id<User> currentUserId, string comment)
    {
        AuditRecordHeading<ApprovalRule> heading = AuditRecordHeadingFactory<ApprovalRule>.CreateNew(currentUserId);

        var result = new ApprovalRuleDeactivatedAuditRecord(heading, comment);

        return result;
    }
}
