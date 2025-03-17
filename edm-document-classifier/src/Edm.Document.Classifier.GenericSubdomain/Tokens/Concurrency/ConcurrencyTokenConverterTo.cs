using Google.Protobuf.WellKnownTypes;

namespace Edm.Document.Classifier.GenericSubdomain.Tokens.Concurrency;

public static class ConcurrencyTokenConverterTo
{
    public static string ToString<T>(ConcurrencyToken<T> concurrencyToken)
    {
        var result = concurrencyToken.Value.Value.ToString(ConcurrencyToken<T>.OutputStringFormat);

        return result;
    }

    public static DateTime ToDateTime<T>(ConcurrencyToken<T> concurrencyToken)
    {
        var result = UtcDateTimeConverterTo.ToDateTime(concurrencyToken.Value);

        return result;
    }

    public static Timestamp ToTimestamp<T>(ConcurrencyToken<T> concurrencyToken)
    {
        Timestamp result = UtcDateTimeConverterTo.ToTimeStamp(concurrencyToken.Value);

        return result;
    }
}
