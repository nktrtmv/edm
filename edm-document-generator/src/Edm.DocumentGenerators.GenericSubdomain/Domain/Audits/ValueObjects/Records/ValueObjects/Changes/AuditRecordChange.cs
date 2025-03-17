namespace Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Changes;

public sealed class AuditRecordChange<T>
{
    public AuditRecordChange(T from, T to)
    {
        From = from;
        To = to;
    }

    public T From { get; }
    public T To { get; }
}
