namespace Edm.DocumentGenerators.GenericSubdomain;

public readonly record struct Metadata<T>
{
    public static Metadata<T> Empty = new Metadata<T>(string.Empty);

    internal readonly string Value;

    internal Metadata(string value)
    {
        Value = value;
    }

    public bool IsEqualTo(string value)
    {
        bool result = Value == value;

        return result;
    }
}
