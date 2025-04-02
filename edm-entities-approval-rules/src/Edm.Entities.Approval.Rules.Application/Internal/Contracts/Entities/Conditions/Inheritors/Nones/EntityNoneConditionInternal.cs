namespace Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.Nones;

public sealed class EntityNoneConditionInternal : EntityConditionInternal
{
    public static readonly EntityNoneConditionInternal Instance = new EntityNoneConditionInternal();

    private EntityNoneConditionInternal()
    {
    }
}
