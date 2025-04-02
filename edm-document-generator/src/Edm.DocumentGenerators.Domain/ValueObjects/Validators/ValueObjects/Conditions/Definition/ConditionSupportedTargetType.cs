namespace Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.Definition;

[Flags]
public enum ConditionSupportedTargetType
{
    None = 0,
    AttributeValue = 1,
    Constant = 2
}
