using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Edm.DocumentGenerator.Gateway.Core.Counters.Commands.Create;
using Edm.DocumentGenerator.Gateway.Core.Counters.Commands.Create.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Counters.Commands.Update;
using Edm.DocumentGenerator.Gateway.Core.Counters.Commands.Update.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Counters.Queries.Get;
using Edm.DocumentGenerator.Gateway.Core.Counters.Queries.Get.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Counters.Queries.GetCounters;
using Edm.DocumentGenerator.Gateway.Core.Counters.Queries.GetCounters.Contracts;

namespace Edm.DocumentGenerator.Gateway.Presentation.Controllers;

[Route("document-counters")]
[ApiController]
[Authorize]
public class DocumentCountersController(
    GetCountersService getCountersService,
    CreateCounterService createCounterService,
    UpdateCounterService updateCounterService,
    GetCounterService getCounterService) : ControllerBase
{
    [HttpPost(nameof(GetAllCounters))]
    public async Task<GetAllCountersQueryResponseBff> GetAllCounters(GetAllCountersQueryBff query, CancellationToken cancellationToken)
    {
        var response = await getCountersService.GetAll(query, cancellationToken);

        return response;
    }

    [HttpPost(nameof(GetCounter))]
    public async Task<GetCounterQueryResponseBff> GetCounter(GetCounterQueryBff query, CancellationToken cancellationToken)
    {
        var result = await getCounterService.Get(query, cancellationToken);

        return result;
    }

    [HttpPut(nameof(UpdateCounter))]
    public async Task<UpdateCounterCommandResponseBff> UpdateCounter([FromBody] UpdateCounterCommandBff command, CancellationToken cancellationToken)
    {
        var result = await updateCounterService.Update(command, cancellationToken);

        return result;
    }

    [HttpPost(nameof(CreateCounter))]
    public async Task<CreateCounterCommandResponseBff> CreateCounter([FromBody] CreateCounterCommandBff command, CancellationToken cancellationToken)
    {
        var result = await createCounterService.Create(command, cancellationToken);

        return result;
    }
}
