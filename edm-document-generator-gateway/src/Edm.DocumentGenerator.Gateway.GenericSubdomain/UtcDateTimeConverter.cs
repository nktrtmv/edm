using Google.Protobuf.WellKnownTypes;

namespace Edm.DocumentGenerator.Gateway.GenericSubdomain;

public static class UtcDateTimeConverter
{
    public static DateTime FromTimestampToDateTime(Timestamp timestamp)
    {
        var value = UtcDateTimeConverterFrom<DateTime>.FromTimestamp(timestamp);

        var result = UtcDateTimeConverterTo.ToDateTime(value);

        return result;
    }
}
