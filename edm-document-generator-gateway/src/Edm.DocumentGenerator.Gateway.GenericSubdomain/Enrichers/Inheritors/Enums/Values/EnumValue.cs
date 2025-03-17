using JetBrains.Annotations;

namespace Edm.DocumentGenerator.Gateway.GenericSubdomain.Enrichers.Inheritors.Enums.Values;

[UsedImplicitly]
public sealed class EnumValue<T>
{
    internal EnumValue(int id)
    {
        Id = id;
    }

    public int Id { get; init; }
    public string? Value { get; internal set; }
}
