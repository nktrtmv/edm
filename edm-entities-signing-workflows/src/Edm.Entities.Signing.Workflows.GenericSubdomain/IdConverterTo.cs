namespace Edm.Entities.Signing.Workflows.GenericSubdomain;

public static class IdConverterTo
{
    public static Guid ToGuid<T>(Id<T> id)
    {
        try
        {
            Guid result = Guid.Parse(id.Value);

            return result;
        }
        catch (FormatException e)
        {
            throw new ArgumentException($"Failed to convert id to Guid (type: Id<{typeof(T)}>, value: {id.Value})", e);
        }
    }

    public static string ToString<T>(Id<T> id)
    {
        string result = id.Value;

        return result;
    }
}
