namespace Edm.DocumentGenerator.Gateway.Core.Contracts;

public sealed class EnumMapBff<T> where T : Enum
{
    public required T EnumValue { get; set; }
    public required string EnumName { get; set; }
}
