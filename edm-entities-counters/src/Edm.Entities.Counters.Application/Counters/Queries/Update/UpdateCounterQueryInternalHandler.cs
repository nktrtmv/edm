using Edm.Entities.Counters.Application.Contracts.Counters;
using Edm.Entities.Counters.Application.Counters.Queries.Update.Contracts;
using Edm.Entities.Counters.Domain.Entities.Counters;
using Edm.Entities.Counters.Domain.Entities.Markers;
using Edm.Entities.Counters.GenericSubdomain;
using Edm.Entities.Counters.Infrastructure.Abstractions.Repositories;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Counters.Application.Counters.Queries.Update;

[UsedImplicitly]
internal sealed class UpdateCounterQueryInternalHandler(ICounterRepository repository) : IRequestHandler<UpdateCounterQueryInternal, UpdateCounterQueryInternalResponse>
{
    public async Task<UpdateCounterQueryInternalResponse> Handle(UpdateCounterQueryInternal request, CancellationToken cancellationToken)
    {
        Validate(request);

        Counter counter = await repository.GetByIdRequired(request.DomainId.ToString(), request.CounterId.ToString(), cancellationToken);

        Id<EntityType>? entityTypeId = NullableConverter.Convert(counter.EntityTypeId, IdConverterFrom<EntityType>.From);

        counter.Update(entityTypeId, request.Name, request.Value);

        await repository.Upsert(counter, cancellationToken);

        Id<CounterInternal> counterId = IdConverterFrom<CounterInternal>.From(counter.Id);

        var result = new UpdateCounterQueryInternalResponse(counterId);

        return result;
    }

    private void Validate(UpdateCounterQueryInternal request)
    {
        if (string.IsNullOrEmpty(request.Name))
        {
            throw new ApplicationException("Имя счётчика не должно быть пустым");
        }

        if (request.Value < 0)
        {
            throw new ApplicationException("Значение счётчика должно быть больше либо равно 0");
        }
    }
}
