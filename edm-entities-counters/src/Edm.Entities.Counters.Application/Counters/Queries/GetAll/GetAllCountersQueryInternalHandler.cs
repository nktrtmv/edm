using Edm.Entities.Counters.Application.Contracts.Counters;
using Edm.Entities.Counters.Application.Counters.Queries.GetAll.Contracts;
using Edm.Entities.Counters.Domain.Entities.Counters;
using Edm.Entities.Counters.Domain.Entities.Markers;
using Edm.Entities.Counters.GenericSubdomain;
using Edm.Entities.Counters.Infrastructure.Abstractions.Repositories;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Counters.Application.Counters.Queries.GetAll;

[UsedImplicitly]
internal sealed class GetAllCountersQueryInternalHandler : IRequestHandler<GetAllCountersQueryInternal, GetAllCountersQueryInternalResponse>
{
    public GetAllCountersQueryInternalHandler(ICounterRepository repository)
    {
        Repository = repository;
    }

    private ICounterRepository Repository { get; }

    public async Task<GetAllCountersQueryInternalResponse> Handle(GetAllCountersQueryInternal request, CancellationToken cancellationToken)
    {
        Id<EntityDomain> domainId = IdConverterFrom<EntityDomain>.From(request.DomainId);

        Counter[]? counters = await Repository.GetAll(domainId, cancellationToken);

        if (counters is null)
        {
            throw new ApplicationException("There is no Counters with given domain id.");
        }

        CounterInternal[] countersInternal = counters.Select(CounterInternalConverter.FromDomain).ToArray();

        var result = new GetAllCountersQueryInternalResponse(countersInternal);

        return result;
    }
}
