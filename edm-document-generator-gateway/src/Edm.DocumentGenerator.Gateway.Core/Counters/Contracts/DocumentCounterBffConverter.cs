using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.Counters.Contracts;

internal static class DocumentCounterBffConverter
{
    public static DocumentCounterBff ToBff(DocumentCounterExternal documentCounterExternal)
    {
        var result = new DocumentCounterBff
        {
            Id = documentCounterExternal.Id,
            EntityTypeId = documentCounterExternal.EntityTypeId,
            Name = documentCounterExternal.Name,
            Value = documentCounterExternal.Value
        };

        return result;
    }
}
