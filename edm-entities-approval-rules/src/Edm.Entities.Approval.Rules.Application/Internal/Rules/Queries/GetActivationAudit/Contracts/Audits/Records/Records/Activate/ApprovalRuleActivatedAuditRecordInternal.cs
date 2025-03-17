using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Application.Records;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Application.Records.ValueObjects.Headings;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetActivationAudit.Contracts.Audits.Records.Records.Activate;

public sealed class ApprovalRuleActivatedAuditRecordInternal : AuditRecordInternal<ApprovalRuleInternal>
{
    public ApprovalRuleActivatedAuditRecordInternal(AuditRecordHeadingInternal<ApprovalRuleInternal> heading, string comment) : base(heading)
    {
        Comment = comment;
    }

    public string Comment { get; }
}
