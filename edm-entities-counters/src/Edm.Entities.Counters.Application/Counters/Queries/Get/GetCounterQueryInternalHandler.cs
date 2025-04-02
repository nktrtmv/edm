using Edm.Entities.Counters.Application.Contracts.Counters;
using Edm.Entities.Counters.Application.Counters.Queries.Get.Contracts;
using Edm.Entities.Counters.Domain.Entities.Counters;
using Edm.Entities.Counters.Infrastructure.Abstractions.Repositories;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Counters.Application.Counters.Queries.Get;

[UsedImplicitly]
internal sealed class GetCounterQueryInternalHandler(ICounterRepository repository) : IRequestHandler<GetCounterQueryInternal, GetCounterQueryInternalResponse>
{
    public async Task<GetCounterQueryInternalResponse> Handle(GetCounterQueryInternal request, CancellationToken cancellationToken)
    {
        Counter counter = await repository.GetByIdRequired(request.DomainId.ToString(), request.CounterId.ToString(), cancellationToken);

        CounterInternal counterInternal = CounterInternalConverter.FromDomain(counter);

        var result = new GetCounterQueryInternalResponse(counterInternal);

        return result;
    }
}
