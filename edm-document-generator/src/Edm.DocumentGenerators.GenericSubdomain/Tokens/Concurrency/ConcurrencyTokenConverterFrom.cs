using System.Globalization;

using Google.Protobuf.WellKnownTypes;

namespace Edm.DocumentGenerators.GenericSubdomain.Tokens.Concurrency;

public static class ConcurrencyTokenConverterFrom<T>
{
    public static ConcurrencyToken<T> From<TSource>(ConcurrencyToken<TSource> concurrencyToken)
    {
        var result = new ConcurrencyToken<T>(UtcDateTimeConverterFrom<T>.From(concurrencyToken.Value));

        return result;
    }

    public static ConcurrencyToken<T> FromString(string concurrencyToken)
    {
        DateTime dateTime = DateTime.ParseExact(concurrencyToken, ConcurrencyToken<T>.OutputStringFormat, null, DateTimeStyles.RoundtripKind);
        UtcDateTime<T> value = UtcDateTimeConverterFrom<T>.FromUtcDateTime(dateTime);

        var result = new ConcurrencyToken<T>(value);

        return result;
    }

    public static ConcurrencyToken<T> FromTimestamp(Timestamp timestamp)
    {
        UtcDateTime<T> value = UtcDateTimeConverterFrom<T>.FromTimestamp(timestamp);

        var result = new ConcurrencyToken<T>(value);

        return result;
    }

    public static ConcurrencyToken<T> FromUnspecifiedUtcDateTime(DateTime concurrencyToken)
    {
        UtcDateTime<T> value = UtcDateTimeConverterFrom<T>.FromUnspecifiedUtcDateTime(concurrencyToken);

        var result = new ConcurrencyToken<T>(value);

        return result;
    }
}
