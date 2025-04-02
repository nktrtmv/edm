using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.ExternalServices;

public static class EnumConverter
{
    public static T ToEnum<T>(int value, Func<int, T> covert) where T : struct, Enum
    {
        if (value == 0)
        {
            throw new ArgumentTypeOutOfRangeException(value);
        }

        var result = covert(value);

        return result;
    }
}
