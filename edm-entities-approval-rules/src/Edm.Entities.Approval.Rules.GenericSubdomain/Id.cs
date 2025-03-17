using System.Text.Json.Serialization;

namespace Edm.Entities.Approval.Rules.GenericSubdomain;

public sealed class Id<T> : IComparable<Id<T>>, IEquatable<Id<T>>
{
    [JsonConstructor]
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

    public bool Equals(Id<T>? other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || (obj is Id<T> other && Equals(other));
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
