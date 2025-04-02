namespace Edm.DocumentGenerators.GenericSubdomain;

public readonly record struct Number<T> : IComparable<Number<T>>
{
    internal Number(long value)
    {
        Value = value;
    }

    public long Value { get; }

    public int CompareTo(Number<T> other)
    {
        return Value.CompareTo(other.Value);
    }

    public static Number<T> operator ++(Number<T> number)
    {
        long value = number.Value + 1;

        var result = new Number<T>(value);

        return result;
    }

    public static bool operator >(Number<T> firstValue, Number<T> secondValue)
    {
        bool result = firstValue.Value > secondValue.Value;

        return result;
    }

    public static bool operator <(Number<T> firstValue, Number<T> secondValue)
    {
        bool result = firstValue.Value < secondValue.Value;

        return result;
    }

    public static bool operator >=(Number<T> firstValue, Number<T> secondValue)
    {
        bool result = firstValue.Value >= secondValue.Value;

        return result;
    }

    public static bool operator <=(Number<T> firstValue, Number<T> secondValue)
    {
        bool result = firstValue.Value <= secondValue.Value;

        return result;
    }

    public override string ToString()
    {
        var result = NumberConverterTo.ToString(this);

        return result;
    }
}
