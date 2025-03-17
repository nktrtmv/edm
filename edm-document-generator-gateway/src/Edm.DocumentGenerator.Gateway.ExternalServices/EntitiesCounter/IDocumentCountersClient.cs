using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts.Commands.Create;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts.Commands.Update;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts.Queries.Get;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter;

public interface IDocumentCountersClient
{
    Task<GetAllDocumentCountersQueryResponse> GetAll(string domainId, CancellationToken cancellationToken);
    Task<GetCounterQueryResponseExternal> Get(GetCounterQueryExternal query, CancellationToken cancellationToken);
    Task<UpdateCounterCommandResponseExternal> Update(UpdateCounterCommandExternal command, CancellationToken cancellationToken);
    Task<CreateCounterCommandResponseExternal> Create(CreateCounterCommandExternal command, CancellationToken cancellationToken);
}
