using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Audits.Records.Activate;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Audits.Records.Deactivate;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Records;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Audits.Records;

internal static class ApprovalRuleAuditRecordDbFromDomainConverter
{
    internal static ApprovalRuleAuditRecordDb FromDomain<T>(AuditRecord<T> record)
    {
        var updatedBy = IdConverterTo.ToString(record.Heading.UpdatedBy);

        Timestamp updatedAt = UtcDateTimeConverterTo.ToTimeStamp(record.Heading.UpdatedAt);

        var result = new ApprovalRuleAuditRecordDb
        {
            UpdatedBy = updatedBy,
            UpdatedAt = updatedAt
        };

        _ = record switch
        {
            ApprovalRuleActivatedAuditRecord activated => ToActivated(result, activated.Comment),
            ApprovalRuleDeactivatedAuditRecord deactivated => ToDeactivated(result, deactivated.Comment),
            _ => throw new ArgumentTypeOutOfRangeException(record)
        };

        return result;
    }

    private static None ToActivated(ApprovalRuleAuditRecordDb record, string comment)
    {
        record.Activated = new ApprovalRuleActivatedRecordDb
        {
            Comment = comment
        };

        return default;
    }

    private static None ToDeactivated(ApprovalRuleAuditRecordDb record, string comment)
    {
        record.Deactivated = new ApprovalRuleDeactivatedRecordDb
        {
            Comment = comment
        };

        return default;
    }
}
