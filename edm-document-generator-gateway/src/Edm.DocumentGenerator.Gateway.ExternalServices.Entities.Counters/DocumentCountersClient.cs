using Edm.Entities.Counters.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Counters.Converters.Commands.Create;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Counters.Converters.Commands.Update;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Counters.Converters.Queries.Get;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Counters.Converters.Queries.GetAll;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts.Commands.Create;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts.Commands.Update;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts.Queries.Get;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Counters;

internal sealed class DocumentCountersClient(EntitiesCountersService.EntitiesCountersServiceClient countersServiceClient) : IDocumentCountersClient
{
    public async Task<GetAllDocumentCountersQueryResponse> GetAll(string domainId, CancellationToken cancellationToken)
    {
        var query = new GetAllEntitiesCountersQuery
        {
            DomainId = domainId
        };

        var response = await countersServiceClient.GetAllAsync(query, cancellationToken: cancellationToken);

        var result = GetAllDocumentCountersQueryResponseConverter.FromDto(response);

        return result;
    }

    public async Task<GetCounterQueryResponseExternal> Get(GetCounterQueryExternal queryExternal, CancellationToken cancellationToken)
    {
        var query = GetCounterQueryExternalConverter.ToDto(queryExternal);

        var response = await countersServiceClient.GetAsync(query, cancellationToken: cancellationToken);

        var result = GetCounterQueryResponseConverterExternal.FromDto(response);

        return result;
    }

    public async Task<UpdateCounterCommandResponseExternal> Update(UpdateCounterCommandExternal commandExternal, CancellationToken cancellationToken)
    {
        var query = UpdateCounterCommandExternalConverter.ToDto(commandExternal);

        var response = await countersServiceClient.UpdateAsync(query, cancellationToken: cancellationToken);

        var result = UpdateCounterCommandResponseExternalConverter.FromDto(response);

        return result;
    }

    public async Task<CreateCounterCommandResponseExternal> Create(CreateCounterCommandExternal commandExternal, CancellationToken cancellationToken)
    {
        var query = CreateCounterCommandExternalConverter.ToDto(commandExternal);

        var response = await countersServiceClient.CreateAsync(query, cancellationToken: cancellationToken);

        var result = CreateCounterCommandResponseExternalConverter.FromDto(response);

        return result;
    }
}
