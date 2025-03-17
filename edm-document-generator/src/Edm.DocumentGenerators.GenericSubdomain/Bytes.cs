namespace Edm.DocumentGenerators.GenericSubdomain;

public sealed record Bytes<T>
{
    public static readonly Bytes<T> Empty = new Bytes<T>(Array.Empty<byte>());

    internal Bytes(byte[] value)
    {
        Value = value;
    }

    internal byte[] Value { get; }
}
