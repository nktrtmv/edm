namespace Edm.DocumentGenerators.GenericSubdomain;

public static class NumberConverterTo
{
    public static long ToLong<T>(Number<T> number)
    {
        long result = number.Value;

        return result;
    }

    public static string ToString<T>(Number<T> number)
    {
        var result = number.Value.ToString();

        return result;
    }
}
