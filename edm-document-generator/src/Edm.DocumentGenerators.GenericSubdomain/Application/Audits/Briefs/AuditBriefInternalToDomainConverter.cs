using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.Markers;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Briefs;

namespace Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Briefs;

public static class AuditBriefInternalToDomainConverter<T>
{
    internal static AuditBrief<T> ToDomain<TInternal>(AuditBriefInternal<TInternal> document)
    {
        Id<AuditUser> createdById = IdConverterFrom<AuditUser>.From(document.CreatedById);

        Id<AuditUser> updatedById = IdConverterFrom<AuditUser>.From(document.UpdatedById);

        UtcDateTime<AuditDateTime> createdDateTime = UtcDateTimeConverterFrom<AuditDateTime>.From(document.CreatedDateTime);

        UtcDateTime<AuditDateTime> updatedDateTime = UtcDateTimeConverterFrom<AuditDateTime>.From(document.UpdatedDateTime);

        var result = new AuditBrief<T>(createdById, updatedById, createdDateTime, updatedDateTime);

        return result;
    }
}
