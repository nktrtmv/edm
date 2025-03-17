using Google.Protobuf.WellKnownTypes;

namespace Edm.Document.Searcher.GenericSubdomain;

public static class UtcDateTimeConverter
{
    public static DateTime FromTimestampToDateTime(Timestamp timestamp)
    {
        UtcDateTime<DateTime> value = UtcDateTimeConverterFrom<DateTime>.FromTimestamp(timestamp);

        var result = UtcDateTimeConverterTo.ToDateTime(value);

        return result;
    }
}
