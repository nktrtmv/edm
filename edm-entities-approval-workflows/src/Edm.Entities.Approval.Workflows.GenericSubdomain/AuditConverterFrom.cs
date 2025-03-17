namespace Edm.Entities.Approval.Workflows.GenericSubdomain;

public static class AuditConverterFrom<T>
{
    public static Audit<T> FromNow()
    {
        UtcDateTime<T> createdDate = UtcDateTime<T>.Now;

        var result = new Audit<T>(createdDate, createdDate);

        return result;
    }

    public static Audit<T> From(DateTime createdDateTime, DateTime updatedDateTime)
    {
        UtcDateTime<T> createdDate = UtcDateTimeConverterFrom<T>.FromUnspecifiedUtcDateTime(createdDateTime);
        UtcDateTime<T> updatedDate = UtcDateTimeConverterFrom<T>.FromUnspecifiedUtcDateTime(updatedDateTime);

        var result = new Audit<T>(createdDate, updatedDate);

        return result;
    }

    public static Audit<T> From<TSource>(Audit<TSource> audit)
    {
        UtcDateTime<T> createdDate = UtcDateTimeConverterFrom<T>.From(audit.CreatedAt);
        UtcDateTime<T> updatedDate = UtcDateTimeConverterFrom<T>.From(audit.UpdatedAt);

        var result = new Audit<T>(createdDate, updatedDate);

        return result;
    }
}
