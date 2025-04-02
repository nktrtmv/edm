using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.Markers;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Briefs;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Briefs.Factories;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records;

namespace Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.Factories;

public static class AuditFactory<T>
{
    public static Audit<T> CreateNew<TUser>(Id<TUser> currentUserId, params AuditRecord<T>[] records)
    {
        Id<AuditUser> auditUserId = IdConverterFrom<AuditUser>.From(currentUserId);

        AuditBrief<T> brief = AuditBriefFactory<T>.CreateNew(auditUserId);

        Audit<T> result = CreateFromDb(brief, records);

        return result;
    }

    public static Audit<T> CreateFrom(Audit<T> audit, AuditRecord<T> record)
    {
        AuditRecord<T>[] records = audit.Records.Concat(new[] { record }).ToArray();

        Audit<T> result = CreateFrom(audit, record.Heading.UpdatedById, record.Heading.UpdatedDateTime, records);

        return result;
    }

    public static Audit<T> CreateFrom(
        Audit<T> audit,
        Id<AuditUser> updatedById,
        UtcDateTime<AuditDateTime> updatedDateTime,
        AuditRecord<T>[] records)
    {
        AuditBrief<T> brief = AuditBriefFactory<T>.CreateFrom(audit.Brief, updatedById, updatedDateTime);

        Audit<T> result = CreateFromDb(brief, records);

        return result;
    }

    public static Audit<T> CreateFromDb(AuditBrief<T> brief, AuditRecord<T>[] records)
    {
        var result = new Audit<T>(brief, records);

        return result;
    }
}
