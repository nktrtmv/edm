using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.Factories;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.Markers;

namespace Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.Services.Updaters;

public static class AuditUpdater
{
    public static Audit<TAudit> Update<TAudit, TUser>(Audit<TAudit> audit, Id<TUser> user)
    {
        Id<AuditUser> updatedById = IdConverterFrom<AuditUser>.From(user);

        UtcDateTime<AuditDateTime> updatedDateTime = UtcDateTime<AuditDateTime>.Now;

        Audit<TAudit> result = AuditFactory<TAudit>.CreateFrom(
            audit,
            updatedById,
            updatedDateTime,
            audit.Records);

        return result;
    }
}
