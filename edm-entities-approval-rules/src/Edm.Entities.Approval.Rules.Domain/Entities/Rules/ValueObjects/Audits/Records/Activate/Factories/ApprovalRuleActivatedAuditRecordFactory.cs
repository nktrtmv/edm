using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Records.ValueObjects.Headings;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Records.ValueObjects.Headings.Factories;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Audits.Records.Activate.Factories;

internal static class ApprovalRuleActivatedAuditRecordFactory
{
    internal static ApprovalRuleActivatedAuditRecord CreateNew(Id<User> currentUserId, string comment)
    {
        AuditRecordHeading<ApprovalRule> heading = AuditRecordHeadingFactory<ApprovalRule>.CreateNew(currentUserId);

        var result = new ApprovalRuleActivatedAuditRecord(heading, comment);

        return result;
    }
}
