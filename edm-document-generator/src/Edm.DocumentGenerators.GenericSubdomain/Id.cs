using System.Text.Json.Serialization;

namespace Edm.DocumentGenerators.GenericSubdomain;

public sealed class Id<T> : IComparable<Id<T>>, IEquatable<Id<T>>
{
    public static readonly Id<T> Empty = IdConverterFrom<T>.FromString(string.Empty);

    public static readonly Id<T> Empty01 = IdConverterFrom<T>.FromString("CD000000-0000-0000-0000-000000000001");

    internal Id(string value)
    {
        Value = value;
    }

    [JsonInclude]
    public string Value { get; }

    public int CompareTo(Id<T>? other)
    {
        int result = Comparer<string>.Default.Compare(Value, other?.Value);

        return result;
    }

    public bool Equals(Id<T>? other)
    {
        bool result = Value == other?.Value;

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

    public bool IsEqualTo(string value)
    {
        bool result = Value == value;

        return result;
    }

    public bool IsEqualTo<TOther>(Id<TOther> other)
    {
        bool result = Value == other.Value;

        return result;
    }

    public bool IsNullOrWhiteSpace()
    {
        bool result = string.IsNullOrWhiteSpace(Value);

        return result;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        return Equals((Id<T>)obj);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(Id<T>? left, Id<T>? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Id<T>? left, Id<T>? right)
    {
        return !Equals(left, right);
    }
}
