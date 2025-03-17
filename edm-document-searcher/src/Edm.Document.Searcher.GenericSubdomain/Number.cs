namespace Edm.Document.Searcher.GenericSubdomain;

public readonly record struct Number<T> : IComparable<Number<T>>
{
    internal Number(long value)
    {
        Value = value;
    }

    internal long Value { get; }

    public int CompareTo(Number<T> other)
    {
        return Value.CompareTo(other.Value);
    }
}
