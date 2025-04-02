namespace Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Abstractions;

public abstract class EntityAttributeValueGenericInternal<T> : EntityAttributeValueInternal
{
    protected EntityAttributeValueGenericInternal(int id, T[] value) : base(id)
    {
        Value = value;
    }

    public T[] Value { get; }
}
