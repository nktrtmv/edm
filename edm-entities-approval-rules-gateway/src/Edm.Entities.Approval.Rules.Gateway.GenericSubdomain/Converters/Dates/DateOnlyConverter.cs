using Google.Protobuf.WellKnownTypes;

namespace Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Converters.Dates;

public static class DateOnlyConverter
{
    public static DateOnly FromDto(Timestamp value)
    {
        var result = DateOnly.FromDateTime(value.ToDateTime());

        return result;
    }

    public static Timestamp ToDto(DateOnly value)
    {
        var dateTime = value.ToDateTime(new TimeOnly(0, 0), DateTimeKind.Utc);

        var result = Timestamp.FromDateTime(dateTime);

        return result;
    }
}
