using Google.Protobuf.WellKnownTypes;

namespace Edm.Entities.Approval.Workflows.GenericSubdomain;

public static class UtcDateTimeConverterFrom<T>
{
    public static UtcDateTime<T> FromUtcDateTime(DateTime dateTime)
    {
        if (dateTime.Kind != DateTimeKind.Utc)
        {
            throw new ArgumentException("DateTime kind shall be in UTC time format.", nameof(dateTime));
        }

        var result = new UtcDateTime<T>(dateTime);

        return result;
    }

    public static UtcDateTime<T> FromUnspecifiedUtcDateTime(DateTime dateTime)
    {
        if (dateTime.Kind != DateTimeKind.Unspecified)
        {
            throw new ArgumentException("DateTime kind shall be Unspecified.", nameof(dateTime));
        }

        DateTime value = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);

        var result = new UtcDateTime<T>(value);

        return result;
    }

    public static UtcDateTime<T> FromTimestamp(Timestamp dateTime)
    {
        var value = dateTime.ToDateTime();

        UtcDateTime<T> result = FromUtcDateTime(value);

        return result;
    }

    public static UtcDateTime<T> From<TSource>(UtcDateTime<TSource> utcDateTime)
    {
        var result = new UtcDateTime<T>(utcDateTime.Value);

        return result;
    }
}
