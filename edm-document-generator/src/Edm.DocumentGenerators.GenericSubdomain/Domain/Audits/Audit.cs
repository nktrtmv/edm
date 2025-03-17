using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Briefs;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records;

namespace Edm.DocumentGenerators.GenericSubdomain.Domain.Audits;

public sealed class Audit<T>
{
    public Audit(AuditBrief<T> brief, AuditRecord<T>[] records)
    {
        Brief = brief;
        Records = records;
    }

    public AuditBrief<T> Brief { get; }
    public AuditRecord<T>[] Records { get; }
}
