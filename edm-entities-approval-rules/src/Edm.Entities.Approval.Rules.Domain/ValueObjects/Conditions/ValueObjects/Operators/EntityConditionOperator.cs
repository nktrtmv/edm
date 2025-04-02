namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.ValueObjects.Operators;

public abstract class EntityConditionOperator
{
    protected EntityConditionOperator(string displayName)
    {
        DisplayName = displayName;
    }

    public string DisplayName { get; }

    public override string ToString()
    {
        return $"{{ Type: {GetType().Name}, DisplayName: {DisplayName} }}";
    }
}
