using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Audits.Records.Activate;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Audits.Records.Deactivate;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Records;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Records.ValueObjects.Headings;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Audits.Records;

internal static class ApprovalRuleAuditRecordDbToDomainConverter
{
    internal static AuditRecord<ApprovalRule> ToDomain(ApprovalRuleAuditRecordDb record)
    {
        Id<AuditUser> updatedBy = IdConverterFrom<AuditUser>.FromString(record.UpdatedBy);
        UtcDateTime<AuditDateTime> updatedAt = UtcDateTimeConverterFrom<AuditDateTime>.FromTimestamp(record.UpdatedAt);

        var heading = new AuditRecordHeading<ApprovalRule>(updatedBy, updatedAt);

        AuditRecord<ApprovalRule> result = record.RecordCase switch
        {
            ApprovalRuleAuditRecordDb.RecordOneofCase.Activated => ToActivated(heading, record.Activated.Comment),
            ApprovalRuleAuditRecordDb.RecordOneofCase.Deactivated => ToDeactivated(heading, record.Deactivated.Comment),
            _ => throw new ArgumentOutOfRangeException()
        };

        return result;
    }

    private static AuditRecord<ApprovalRule> ToActivated(AuditRecordHeading<ApprovalRule> heading, string comment)
    {
        var result = new ApprovalRuleActivatedAuditRecord(heading, comment);

        return result;
    }

    private static AuditRecord<ApprovalRule> ToDeactivated(AuditRecordHeading<ApprovalRule> heading, string comment)
    {
        var result = new ApprovalRuleDeactivatedAuditRecord(heading, comment);

        return result;
    }
}
