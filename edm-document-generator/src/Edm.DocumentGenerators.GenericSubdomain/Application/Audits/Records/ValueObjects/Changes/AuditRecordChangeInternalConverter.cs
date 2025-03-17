using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Changes;

namespace Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records.ValueObjects.Changes;

public static class AuditRecordChangeInternalConverter<TInternal>
{
    public static AuditRecordChangeInternal<TInternal> FromDomain<T>(AuditRecordChange<T> change, Func<T, TInternal> converter)
    {
        TInternal from = converter(change.From);
        TInternal to = converter(change.To);

        var result = new AuditRecordChangeInternal<TInternal>(from, to);

        return result;
    }
}
