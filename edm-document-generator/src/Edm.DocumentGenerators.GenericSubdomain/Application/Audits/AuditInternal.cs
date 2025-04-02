using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Briefs;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records;

namespace Edm.DocumentGenerators.GenericSubdomain.Application.Audits;

public sealed class AuditInternal<T>
{
    internal AuditInternal(AuditBriefInternal<T> brief, AuditRecordInternal<T>[] records)
    {
        Brief = brief;
        Records = records;
    }

    public AuditBriefInternal<T> Brief { get; }
    public AuditRecordInternal<T>[] Records { get; }
}
