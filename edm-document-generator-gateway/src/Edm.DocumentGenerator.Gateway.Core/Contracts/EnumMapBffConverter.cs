using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts;

public static class EnumMapBffConverter
{
    public static CollectionQueryResponse<EnumMapBff<T>> ConvertToResponse<T>(Dictionary<T, string> dict) where T : Enum
    {
        IEnumerable<EnumMapBff<T>> items = dict.Select(ToBff).ToArray();

        var result = new CollectionQueryResponse<EnumMapBff<T>>
        {
            Length = dict.Count,
            Items = items
        };

        return result;
    }

    private static EnumMapBff<T> ToBff<T>(KeyValuePair<T, string> e) where T : Enum
    {
        var result = new EnumMapBff<T>
        {
            EnumName = e.Value,
            EnumValue = e.Key
        };

        return result;
    }
}
