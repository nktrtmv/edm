namespace Edm.Entities.Approval.Workflows.GenericSubdomain;

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
            UtcDateTime<T> result = UtcDateTimeConverterFrom<T>.FromUnspecifiedUtcDateTime(DateTime.MinValue);

            return result;
        }
    }

    public int CompareTo(UtcDateTime<T> other)
    {
        int result = Comparer<DateTime>.Default.Compare(Value, other.Value);

        return result;
    }

    public static bool operator <(UtcDateTime<T> left, UtcDateTime<T> right)
    {
        return left.Value < right.Value;
    }

    public static bool operator >(UtcDateTime<T> left, UtcDateTime<T> right)
    {
        return left.Value > right.Value;
    }

    public static bool operator <=(UtcDateTime<T> left, UtcDateTime<T> right)
    {
        return left.Value <= right.Value;
    }

    public static bool operator >=(UtcDateTime<T> left, UtcDateTime<T> right)
    {
        return left.Value >= right.Value;
    }
}
