using Edm.Entities.Counters.Application.Contracts.Counters;
using Edm.Entities.Counters.Application.Counters.Commands.Increment.Contracts;
using Edm.Entities.Counters.GenericSubdomain;
using Edm.Entities.Counters.GenericSubdomain.Tracing;
using Edm.Entities.Counters.Presentation.Abstractions;
using Edm.Entities.Counters.Presentation.Controllers.Counters.Converters.Increment.Values;

using Grpc.Core;

using MediatR;

namespace Edm.Entities.Counters.Presentation.Controllers.Counters;

internal sealed class EntitiesCountersIncrementerController(IMediator mediator, ILogger<EntitiesCountersController> logger)
    : EntitiesCountersIncrementerService.EntitiesCountersIncrementerServiceBase
{
    public override async Task<IncrementEntitiesCountersCommandResponse> Increment(IncrementEntitiesCountersCommand request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(Increment),
            request,
            async () =>
            {
                Id<CounterInternal>[] countersIds = request.EntitiesCountersIds.Select(IdConverterFrom<CounterInternal>.FromString).ToArray();

                string? entityToken = string.IsNullOrWhiteSpace(request.EntityToken) ? null : request.EntityToken;

                var command = new IncrementCountersCommandInternal(countersIds, entityToken);

                IncrementCountersCommandInternalResponse response = await mediator.Send(command, context.CancellationToken);

                EntityCounterValueDto[] entitiesCountersValues =
                    response.CountersValues.Select(EntityCounterValueDtoFromInternalConverter.FromInternal).ToArray();

                var result = new IncrementEntitiesCountersCommandResponse
                {
                    EntitiesCountersValues = { entitiesCountersValues }
                };

                return result;
            });
    }
}
