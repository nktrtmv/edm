namespace Edm.Entities.Signing.Workflows.GenericSubdomain;

public static class NumberConverterTo
{
    public static long ToLong<T>(Number<T> number)
    {
        long result = number.Value;

        return result;
    }
}
