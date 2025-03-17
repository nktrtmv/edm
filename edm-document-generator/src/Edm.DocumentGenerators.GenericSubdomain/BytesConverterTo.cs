using Google.Protobuf;

namespace Edm.DocumentGenerators.GenericSubdomain;

public static class BytesConverterTo
{
    public static TDto ToDto<TDto, T>(Bytes<T> bytes, MessageParser<TDto> parser) where TDto : IMessage<TDto>
    {
        TDto result = parser.ParseFrom(bytes.Value);

        return result;
    }

    public static ByteString ToBytesString<T>(Bytes<T> bytes)
    {
        ByteString result = ByteString.CopyFrom(bytes.Value);

        return result;
    }
}
