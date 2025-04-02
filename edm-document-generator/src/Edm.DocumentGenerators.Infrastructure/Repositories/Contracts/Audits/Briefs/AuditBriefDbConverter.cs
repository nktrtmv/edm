using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Briefs;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Audits.Briefs;

internal static class AuditBriefDbConverter
{
    internal static AuditBriefDb FromDomain<T>(AuditBrief<T> document)
    {
        var createdById = IdConverterTo.ToString(document.CreatedById);

        var updatedById = IdConverterTo.ToString(document.UpdatedById);

        var createdDateTime = UtcDateTimeConverterTo.ToDateTime(document.CreatedDateTime);

        var updatedDateTime = UtcDateTimeConverterTo.ToDateTime(document.UpdatedDateTime);

        var result = new AuditBriefDb(createdById, updatedById, createdDateTime, updatedDateTime);

        return result;
    }
}
