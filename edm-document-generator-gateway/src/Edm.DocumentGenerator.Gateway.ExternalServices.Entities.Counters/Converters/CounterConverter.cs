using Edm.Entities.Counters.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Counters.Converters;

internal static class CounterConverter
{
    public static DocumentCounterExternal From(EntityCounterDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        return new DocumentCounterExternal(dto.Id, dto.EntityTypeId, dto.Name, dto.Value);
    }
}
