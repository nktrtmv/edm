namespace Edm.Entities.Approval.Workflows.GenericSubdomain;

public sealed class Id<T> : IComparable<Id<T>>, IEquatable<Id<T>>
{
    public static readonly Id<T> Empty = IdConverterFrom<T>.FromString(string.Empty);

    internal Id(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public int CompareTo(Id<T>? other)
    {
        int result = Comparer<string>.Default.Compare(Value, other?.Value);

        return result;
    }

    public bool Equals(Id<T>? other)
    {
        return Value == other?.Value;
    }

    public bool IsEqualTo<TOther>(Id<TOther> other)
    {
        bool result = Value == other.Value;

        return result;
    }

    public static bool operator ==(Id<T>? obj1, Id<T>? obj2)
    {
        bool result = obj1?.Value == obj2?.Value;

        return result;
    }

    public static bool operator !=(Id<T>? obj1, Id<T>? obj2)
    {
        bool result = obj1?.Value != obj2?.Value;

        return result;
    }

    public static Id<T> CreateNew()
    {
        Id<T> result = IdConverterFrom<T>.FromGuid(Guid.NewGuid());

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

    public override string ToString()
    {
        var result = IdConverterTo.ToString(this);

        return result;
    }
}
