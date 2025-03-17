using Google.Protobuf.WellKnownTypes;

namespace Edm.Entities.Signing.Workflows.GenericSubdomain;

public static class UtcDateTimeConverterTo
{
    private const string OutputStringFormat = "o";

    public static string ToString<T>(UtcDateTime<T> utcDateTime)
    {
        var result = utcDateTime.Value.ToString(OutputStringFormat);

        return result;
    }

    public static DateTime ToDateTime<T>(UtcDateTime<T> utcDateTime)
    {
        DateTime result = utcDateTime.Value;

        return result;
    }

    public static Timestamp ToTimeStamp<T>(UtcDateTime<T> utcDateTime)
    {
        var result = utcDateTime.Value.ToTimestamp();

        return result;
    }

    public static Timestamp ToTimeStamp(DateTime dateTime)
    {
        Timestamp? result = Timestamp.FromDateTime(dateTime.ToUniversalTime());

        return result;
    }
}
