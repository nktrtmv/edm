namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Data;

public sealed class EntityTypeAttributeData
{
    internal EntityTypeAttributeData(int id, string displayName)
    {
        Id = id;
        DisplayName = displayName;
    }


    //TODO Только для миграции маршрута согласования. Убрать set;
    public int Id { get; set; }
    public string DisplayName { get; }
}
