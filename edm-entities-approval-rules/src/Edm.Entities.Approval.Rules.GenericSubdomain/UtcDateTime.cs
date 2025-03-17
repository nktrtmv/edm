using System.Text.Json.Serialization;

namespace Edm.Entities.Approval.Rules.GenericSubdomain;

public readonly record struct UtcDateTime<T> : IComparable<UtcDateTime<T>>
{
    [JsonConstructor]
    internal UtcDateTime(DateTime value)
    {
        Value = value;
    }

    [JsonInclude]
    public DateTime Value { get; }

    public static UtcDateTime<T> Now => UtcDateTimeConverterFrom<T>.FromUtcDateTime(DateTime.UtcNow);

    public int CompareTo(UtcDateTime<T> other)
    {
        int result = Comparer<DateTime>.Default.Compare(Value, other.Value);

        return result;
    }

    public override string ToString()
    {
        var result = Value.ToString("yyyy-MM-dd HH:mm:ss.ffffff");

        return result;
    }
}
