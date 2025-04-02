using Edm.Entities.Counters.Application.Contracts.Counters;
using Edm.Entities.Counters.Application.Counters.Queries.Create.Contracts;
using Edm.Entities.Counters.Domain.Entities.Counters;
using Edm.Entities.Counters.Domain.Entities.Counters.Factories;
using Edm.Entities.Counters.Domain.Entities.Markers;
using Edm.Entities.Counters.GenericSubdomain;
using Edm.Entities.Counters.Infrastructure.Abstractions.Repositories;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Counters.Application.Counters.Queries.Create;

[UsedImplicitly]
internal sealed class CreateCounterQueryInternalHandler(ICounterRepository repository) : IRequestHandler<CreateCounterQueryInternal, CreateCounterQueryInternalResponse>
{
    public async Task<CreateCounterQueryInternalResponse> Handle(CreateCounterQueryInternal request, CancellationToken cancellationToken)
    {
        Validate(request);

        Id<EntityDomain> domainId = IdConverterFrom<EntityDomain>.From(request.DomainId);

        Id<EntityType>? entityTypeId = NullableConverter.Convert(request.EntityTypeId, IdConverterFrom<EntityType>.From);

        Counter counter = CounterFactory.CreateNew(domainId, entityTypeId, request.Name, request.Value);

        await repository.Upsert(counter, cancellationToken);

        Id<CounterInternal> counterId = IdConverterFrom<CounterInternal>.From(counter.Id);

        var result = new CreateCounterQueryInternalResponse(counterId);

        return result;
    }

    private void Validate(CreateCounterQueryInternal request)
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
