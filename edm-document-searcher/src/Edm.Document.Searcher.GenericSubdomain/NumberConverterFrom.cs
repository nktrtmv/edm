namespace Edm.Document.Searcher.GenericSubdomain;

public static class NumberConverterFrom<T>
{
    public static Number<T> FromInt(int value)
    {
        var result = new Number<T>(value);

        return result;
    }

    public static Number<T> FromLong(long value)
    {
        var result = new Number<T>(value);

        return result;
    }

    public static Number<T> FromDouble(double value)
    {
        var result = new Number<T>((long)value);

        return result;
    }

    public static Number<T> From<TSource>(Number<TSource> number)
    {
        var result = new Number<T>(number.Value);

        return result;
    }

    public static Number<T> FromString(string value)
    {
        long number = long.Parse(value);

        var result = new Number<T>(number);

        return result;
    }
}
