using Edm.Entities.Counters.Application.Contracts.Counters.Contracts;
using Edm.Entities.Counters.GenericSubdomain;
using Edm.Entities.Counters.Presentation.Abstractions;

namespace Edm.Entities.Counters.Presentation.Controllers.Counters.Converters.Increment.Values;

internal static class EntityCounterValueDtoFromInternalConverter
{
    internal static EntityCounterValueDto FromInternal(CounterValueInternal counterValue)
    {
        var id = IdConverterTo.ToString(counterValue.Id);

        var result = new EntityCounterValueDto
        {
            Id = id,
            Value = counterValue.Value
        };

        return result;
    }
}
