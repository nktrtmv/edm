using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Briefs;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Briefs.Factories;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Records;

namespace Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.Factories;

public static class AuditFactory<T>
{
    public static Audit<T> CreateNew<TUser>(Id<TUser> currentUserId)
    {
        Id<AuditUser> auditUserId = IdConverterFrom<AuditUser>.From(currentUserId);

        AuditBrief<T> brief = AuditBriefFactory<T>.CreateNew(auditUserId);

        Audit<T> result = CreateFromDb(brief);

        return result;
    }

    public static Audit<T> CreateFrom(Audit<T> audit, AuditRecord<T> record)
    {
        AuditBrief<T> brief = AuditBriefFactory<T>.CreateFrom(audit.Brief, record.Heading.UpdatedBy, record.Heading.UpdatedAt);

        AuditRecord<T>[] records = audit.Records.Concat(new[] { record }).ToArray();

        Audit<T> result = CreateFromDb(brief, records);

        return result;
    }

    public static Audit<T> CreateFrom<TUser>(Audit<T> audit, Id<TUser> currentUserId)
    {
        Id<AuditUser> updatedBy = IdConverterFrom<AuditUser>.From(currentUserId);

        UtcDateTime<AuditDateTime> updatedAt = UtcDateTime<AuditDateTime>.Now;

        AuditBrief<T> brief = AuditBriefFactory<T>.CreateFrom(audit.Brief, updatedBy, updatedAt);

        Audit<T> result = CreateFromDb(brief, audit.Records);

        return result;
    }

    public static Audit<T> CreateFromDb(AuditBrief<T> brief, params AuditRecord<T>[] records)
    {
        var result = new Audit<T>(brief, records);

        return result;
    }
}
