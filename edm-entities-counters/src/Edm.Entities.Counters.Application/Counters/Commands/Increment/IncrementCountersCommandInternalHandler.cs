using Edm.Entities.Counters.Application.Contracts.Counters.Contracts;
using Edm.Entities.Counters.Application.Counters.Commands.Increment.Contracts;
using Edm.Entities.Counters.Application.Counters.Commands.Increment.Validators;
using Edm.Entities.Counters.Domain.Entities.Counters;
using Edm.Entities.Counters.Domain.Entities.Counters.ValueObjects.Values;
using Edm.Entities.Counters.Domain.Entities.Markers;
using Edm.Entities.Counters.GenericSubdomain;
using Edm.Entities.Counters.Infrastructure.Abstractions.Repositories;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Counters.Application.Counters.Commands.Increment;

[UsedImplicitly]
internal sealed class IncrementCountersCommandInternalHandler(ICounterRepository repository)
    : IRequestHandler<IncrementCountersCommandInternal, IncrementCountersCommandInternalResponse>
{
    public async Task<IncrementCountersCommandInternalResponse> Handle(IncrementCountersCommandInternal request, CancellationToken cancellationToken)
    {
        DistinctCountersValidator.Validate(request.CountersIds);

        Id<Counter>[] countersIds = request.CountersIds.Select(IdConverterFrom<Counter>.From).ToArray();

        Id<EntityToken>? entityToken = NullableConverter.Convert(request.EntityToken, IdConverterFrom<EntityToken>.FromString);

        CounterValue[] countersValues = await repository.TryIncrement(countersIds, entityToken, cancellationToken);

        if (countersValues.Length != countersIds.Length)
        {
            throw new ArgumentException("There is no Counters with given Ids.");
        }

        CounterValueInternal[] countersValuesInternal = countersValues.Select(CounterValueInternalConverter.FromDomain).ToArray();

        var result = new IncrementCountersCommandInternalResponse(countersValuesInternal);

        return result;
    }
}
