using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Briefs;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Records;

namespace Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain;

// ReSharper disable once UnusedTypeParameter
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
