namespace Edm.Document.Classifier.GenericSubdomain;

public static class IdConverterTo
{
    public static int ToInt<T>(Id<T> id)
    {
        try
        {
            int result = int.Parse(id.Value);

            return result;
        }
        catch (FormatException e)
        {
            throw new ArgumentException($"Failed to convert id to Int (type: Id<{typeof(T)}>, value: {id.Value})", e);
        }
    }

    public static string ToString<T>(Id<T> id)
    {
        string result = id.Value;

        return result;
    }
}
