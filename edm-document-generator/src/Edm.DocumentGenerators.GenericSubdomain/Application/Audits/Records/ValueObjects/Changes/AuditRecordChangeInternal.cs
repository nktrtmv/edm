namespace Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records.ValueObjects.Changes;

public sealed class AuditRecordChangeInternal<T>
{
    internal AuditRecordChangeInternal(T from, T to)
    {
        From = from;
        To = to;
    }

    public T From { get; }
    public T To { get; }
}
