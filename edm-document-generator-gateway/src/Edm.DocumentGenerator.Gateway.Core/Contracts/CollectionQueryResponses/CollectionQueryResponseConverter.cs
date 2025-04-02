using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.CollectionQueryResponses;

internal static class CollectionQueryResponseConverter
{
    public static CollectionQueryResponse<T> ToBff<T>(T[] segmentsBff)
    {
        var result = new CollectionQueryResponse<T>
        {
            Items = segmentsBff,
            Length = segmentsBff.Length
        };

        return result;
    }
}
