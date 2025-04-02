namespace Edm.Entities.Approval.Rules.GenericSubdomain;

public readonly record struct Metadata<T> : IComparable<Metadata<T>>
{
    public static Metadata<T> Empty = new Metadata<T>(string.Empty);

    internal readonly string Value;

    internal Metadata(string value)
    {
        Value = value;
    }

    public int CompareTo(Metadata<T> other)
    {
        int result = Comparer<string>.Default.Compare(Value, other.Value);

        return result;
    }
}
