using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.GenericSubdomain.Extensions.Types;

public static class TypeCasterTo<T>
{
    public static T CastRequired<TFrom>(TFrom value)
    {
        if (value is null)
        {
            throw new ArgumentException($"Casted object is null.\nDestination type: {typeof(T)}");
        }

        if (value is not T result)
        {
            throw new UnsupportedTypeArgumentException<T>(value);
        }

        return result;
    }
}
