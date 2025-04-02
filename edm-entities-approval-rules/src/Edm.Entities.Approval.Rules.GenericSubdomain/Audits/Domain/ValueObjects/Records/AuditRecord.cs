using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Records.ValueObjects.Headings;

namespace Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain.ValueObjects.Records;

public abstract class AuditRecord<T>
{
    protected AuditRecord(AuditRecordHeading<T> heading)
    {
        Heading = heading;
    }

    public AuditRecordHeading<T> Heading { get; }
}
