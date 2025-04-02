using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain.Extensions.Arrays.Comparers;
using Edm.DocumentGenerators.GenericSubdomain.Extensions.Types;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;

public abstract class DocumentAttributeValueGeneric<T> : DocumentAttributeValue
{
    protected DocumentAttributeValueGeneric(DocumentAttribute attribute, T[] values) : base(attribute)
    {
        Values = values;
    }

    public T[] Values { get; private set; }

    public void SetValues(T[] values)
    {
        Values = values;
    }

    public override int GetHashCode()
    {
        // ReSharper disable once NonReadonlyMemberInGetHashCode
        int result = HashCode.Combine(base.GetHashCode(), Values); // SetValues is used only in patching

        return result;
    }

    public override bool Equals(object? other)
    {
        bool result = base.Equals(other) && Equals((DocumentAttributeValueGeneric<T>)other);

        return result;
    }

    private bool Equals(DocumentAttributeValueGeneric<T> other)
    {
        if (Values.Length != other.Values.Length)
        {
            return false;
        }

        for (var i = 0; i < Values.Length; i++)
        {
            if (!Equals(Values[i], other.Values[i]))
            {
                return false;
            }
        }

        return true;
    }

    public override int CompareTo(DocumentAttributeValue? other)
    {
        DocumentAttributeValueGeneric<T> otherAttributeValue = TypeCasterTo<DocumentAttributeValueGeneric<T>>.CastRequired(other);

        int result = ArrayComparer.CompareTo(Values, otherAttributeValue.Values);

        return result;
    }

    public override string ToString()
    {
        string values = string.Join(", ", Values);

        return $"{{ {BaseToString()}, Values: [{values}] }}";
    }
}
