using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Records;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Records.ValueObjects.Headings;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Audits.Records.Activate;

public sealed class ApprovalRuleActivatedAuditRecord : AuditRecord<ApprovalRule>
{
    public ApprovalRuleActivatedAuditRecord(AuditRecordHeading<ApprovalRule> heading, string comment) : base(heading)
    {
        Comment = comment;
    }

    public string Comment { get; }
}
