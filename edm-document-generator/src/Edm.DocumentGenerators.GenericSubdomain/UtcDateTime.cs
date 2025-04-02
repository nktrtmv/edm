namespace Edm.DocumentGenerators.GenericSubdomain;

public readonly record struct UtcDateTime<T> : IComparable<UtcDateTime<T>>
{
    internal UtcDateTime(DateTime value)
    {
        Value = value;
    }

    public DateTime Value { get; }

    public static UtcDateTime<T> Now
    {
        get
        {
            UtcDateTime<T> result = UtcDateTimeConverterFrom<T>.FromUtcDateTime(DateTime.UtcNow);

            return result;
        }
    }

    public static UtcDateTime<T> MinValue
    {
        get
        {
            UtcDateTime<T> result = UtcDateTimeConverterFrom<T>.FromUtcDateTime(DateTime.SpecifyKind(DateTime.MinValue, DateTimeKind.Utc));

            return result;
        }
    }

    public static UtcDateTime<T> NowWithMicrosecondsPrecision
    {
        get
        {
            UtcDateTime<T> result = UtcDateTimeConverterFrom<T>.FromUtcDateTimeWithMicrosecondsPrecision(DateTime.UtcNow);

            return result;
        }
    }

    public int CompareTo(UtcDateTime<T> other)
    {
        return Value.CompareTo(other.Value);
    }
}
