namespace Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.Definition;

public sealed class SupportedAttributeType
{
    public enum IsArrayEnum
    {
        Any,
        ArrayOnly,
        NotArray
    }

    public SupportedAttributeType(Type type, IsArrayEnum isArray)
    {
        Type = type;
        IsArray = isArray;
    }

    public Type Type { get; init; }
    public IsArrayEnum IsArray { get; init; }
}
