namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Data.Factories;

public static class EntityTypeAttributeDataFactory
{
    public static EntityTypeAttributeData CreateFrom(int id, string displayName)
    {
        var result = new EntityTypeAttributeData(id, displayName);

        return result;
    }
}
