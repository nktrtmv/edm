namespace Edm.Entities.Signing.Workflows.GenericSubdomain;

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

    public static Number<T> From<TSource>(Number<TSource> number)
    {
        var result = new Number<T>(number.Value);

        return result;
    }
}
