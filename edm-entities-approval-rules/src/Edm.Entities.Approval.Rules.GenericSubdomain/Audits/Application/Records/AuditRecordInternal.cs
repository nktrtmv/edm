using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Application.Records.ValueObjects.Headings;

namespace Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Application.Records;

public abstract class AuditRecordInternal<T>
{
    protected AuditRecordInternal(AuditRecordHeadingInternal<T> heading)
    {
        Heading = heading;
    }

    public AuditRecordHeadingInternal<T> Heading { get; }
}
