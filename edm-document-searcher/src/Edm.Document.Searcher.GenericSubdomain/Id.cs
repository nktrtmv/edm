using System.Text.Json.Serialization;

namespace Edm.Document.Searcher.GenericSubdomain;

public readonly record struct Id<T> : IComparable<Id<T>>
{
    public static readonly Id<T> Empty = IdConverterFrom<T>.FromString(string.Empty);

    internal Id(string value)
    {
        Value = value;
    }

    [JsonInclude]
    public string Value { get; }

    public int CompareTo(Id<T> other)
    {
        int result = Comparer<string>.Default.Compare(Value, other.Value);

        return result;
    }

    public bool IsEqualTo<TOther>(Id<TOther> other)
    {
        bool result = Value == other.Value;

        return result;
    }

    public static Id<T> CreateNew()
    {
        Id<T> result = IdConverterFrom<T>.FromGuid(Guid.NewGuid());

        return result;
    }

    public static Id<T> CreateEmpty()
    {
        Id<T> result = IdConverterFrom<T>.FromGuid(Guid.Empty);

        return result;
    }

    public override string ToString()
    {
        var result = IdConverterTo.ToString(this);

        return result;
    }
}
