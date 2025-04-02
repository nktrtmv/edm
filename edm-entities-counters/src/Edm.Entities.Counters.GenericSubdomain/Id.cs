namespace Edm.Entities.Counters.GenericSubdomain;

public readonly record struct Id<T> : IComparable<Id<T>>
{
    public static readonly Id<T> Empty = IdConverterFrom<T>.FromString(string.Empty);

    internal Id(string value)
    {
        Value = value;
    }

    internal string Value { get; }

    public int CompareTo(Id<T> other)
    {
        int result = Comparer<string>.Default.Compare(Value, other.Value);

        return result;
    }

    public static Id<T> CreateNew()
    {
        Id<T> result = IdConverterFrom<T>.FromGuid(Guid.NewGuid());

        return result;
    }

    public override string ToString()
    {
        var result = IdConverterTo.ToString(this);

        return result;
    }
}
