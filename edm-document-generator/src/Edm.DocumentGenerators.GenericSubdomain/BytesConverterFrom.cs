using Google.Protobuf;

namespace Edm.DocumentGenerators.GenericSubdomain;

public static class BytesConverterFrom<T>
{
    public static Bytes<T> From<TSource>(Bytes<TSource> bytes)
    {
        var result = new Bytes<T>(bytes.Value);

        return result;
    }

    public static Bytes<T> FromDto<TDto>(TDto dto) where TDto : IMessage
    {
        byte[] bytes = dto.ToByteArray();

        Bytes<T> result = FromBytes(bytes);

        return result;
    }

    public static Bytes<T> FromByteString(ByteString byteString)
    {
        byte[] bytes = byteString.ToByteArray();

        Bytes<T> result = FromBytes(bytes);

        return result;
    }

    public static Bytes<T> FromBytes(byte[] bytes)
    {
        var result = new Bytes<T>(bytes);

        return result;
    }
}
