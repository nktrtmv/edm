using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;

public abstract class DocumentAttributeValue : IComparable<DocumentAttributeValue>
{
    protected DocumentAttributeValue(DocumentAttribute attribute)
    {
        Attribute = attribute;
    }

    public DocumentAttribute Attribute { get; }

    public Id<DocumentAttribute> Id => Attribute.Id;

    public abstract int CompareTo(DocumentAttributeValue? other);

    public static bool operator ==(DocumentAttributeValue? left, DocumentAttributeValue? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(DocumentAttributeValue? left, DocumentAttributeValue? right)
    {
        return !Equals(left, right);
    }

    public override int GetHashCode()
    {
        return Attribute.GetHashCode();
    }

    public override bool Equals(object? other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (other.GetType() != GetType())
        {
            return false;
        }

        return Equals((DocumentAttributeValue)other);
    }

    private bool Equals(DocumentAttributeValue other)
    {
        return Attribute.Equals(other.Attribute);
    }

    protected string BaseToString()
    {
        return $"Type: {GetType().Name} Id: '{Id}'";
    }
}
