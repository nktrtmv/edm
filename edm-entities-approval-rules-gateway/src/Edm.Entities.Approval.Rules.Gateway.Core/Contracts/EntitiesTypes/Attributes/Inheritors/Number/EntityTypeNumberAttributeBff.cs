namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Inheritors.Number;

public sealed class EntityTypeNumberAttributeBff : EntityTypeAttributeBff
{
    public required int Precision { get; init; }
}
