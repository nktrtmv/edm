namespace Edm.Entities.Signing.Workflows.GenericSubdomain;

public readonly record struct UtcDateTime<T> : IComparable<UtcDateTime<T>>
{
    internal UtcDateTime(DateTime value)
    {
        Value = value;
    }

    internal DateTime Value { get; }

    public static UtcDateTime<T> Now
    {
        get
        {
            UtcDateTime<T> result = UtcDateTimeConverterFrom<T>.FromUtcDateTime(DateTime.UtcNow);

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
