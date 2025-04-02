using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Markers;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Briefs;

namespace Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Briefs;

public static class AuditBriefInternalFromDomainConverter<TInternal>
{
    public static AuditBriefInternal<TInternal> FromDomain<T>(AuditBrief<T> document)
    {
        Id<AuditUserInternal> createdById = IdConverterFrom<AuditUserInternal>.From(document.CreatedById);

        Id<AuditUserInternal> updatedById = IdConverterFrom<AuditUserInternal>.From(document.UpdatedById);

        UtcDateTime<AuditDateTimeInternal> createdDateTime = UtcDateTimeConverterFrom<AuditDateTimeInternal>.From(document.CreatedDateTime);

        UtcDateTime<AuditDateTimeInternal> updatedDateTime = UtcDateTimeConverterFrom<AuditDateTimeInternal>.From(document.UpdatedDateTime);

        var result = new AuditBriefInternal<TInternal>(createdById, updatedById, createdDateTime, updatedDateTime);

        return result;
    }
}
