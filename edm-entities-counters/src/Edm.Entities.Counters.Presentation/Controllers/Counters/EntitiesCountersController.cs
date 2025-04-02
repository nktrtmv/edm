using Edm.Entities.Counters.Application.Contracts.Markers;
using Edm.Entities.Counters.Application.Counters.Queries.Create.Contracts;
using Edm.Entities.Counters.Application.Counters.Queries.Get.Contracts;
using Edm.Entities.Counters.Application.Counters.Queries.GetAll.Contracts;
using Edm.Entities.Counters.Application.Counters.Queries.Update.Contracts;
using Edm.Entities.Counters.GenericSubdomain;
using Edm.Entities.Counters.GenericSubdomain.Tracing;
using Edm.Entities.Counters.Presentation.Abstractions;
using Edm.Entities.Counters.Presentation.Controllers.Counters.Converters;
using Edm.Entities.Counters.Presentation.Controllers.Counters.Converters.Create;
using Edm.Entities.Counters.Presentation.Controllers.Counters.Converters.Get;
using Edm.Entities.Counters.Presentation.Controllers.Counters.Converters.Update;

using Grpc.Core;

using MediatR;

namespace Edm.Entities.Counters.Presentation.Controllers.Counters;

internal sealed class EntitiesCountersController(IMediator mediator, ILogger<EntitiesCountersController> logger) : EntitiesCountersService.EntitiesCountersServiceBase
{
    public override async Task<GetAllEntitiesCountersQueryResponse> GetAll(GetAllEntitiesCountersQuery request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(GetAll),
            request,
            async () =>
            {
                Id<EntityDomainInternal> domainId = IdConverterFrom<EntityDomainInternal>.FromString(request.DomainId);

                var command = new GetAllCountersQueryInternal(domainId);

                GetAllCountersQueryInternalResponse response = await mediator.Send(command, context.CancellationToken);

                EntityCounterDto[] entitiesCounters = response.Counters.Select(EntityCounterDtoFromInternalConverter.FromInternal).ToArray();

                var result = new GetAllEntitiesCountersQueryResponse
                {
                    EntitiesCounters = { entitiesCounters }
                };

                return result;
            });
    }

    public override async Task<GetEntityCounterQueryResponse> Get(GetEntityCounterQuery request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(Get),
            request,
            async () =>
            {
                GetCounterQueryInternal command = GetCounterQueryInternalConverter.FromDto(request);

                GetCounterQueryInternalResponse response = await mediator.Send(command, context.CancellationToken);

                GetEntityCounterQueryResponse result = GetCounterQueryInternalResponseConverter.ToDto(response);

                return result;
            });
    }

    public override async Task<CreateEntityCounterQueryResponse> Create(CreateEntityCounterQuery request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(Create),
            request,
            async () =>
            {
                CreateCounterQueryInternal command = CreateCounterQueryInternalConverter.FromDto(request);

                CreateCounterQueryInternalResponse response = await mediator.Send(command, context.CancellationToken);

                CreateEntityCounterQueryResponse result = CreateCounterQueryInternalResponseConverter.ToDto(response);

                return result;
            });
    }

    public override async Task<UpdateEntityCounterQueryResponse> Update(UpdateEntityCounterQuery request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(Update),
            request,
            async () =>
            {
                UpdateCounterQueryInternal command = UpdateCounterQueryInternalConverter.FromDto(request);

                UpdateCounterQueryInternalResponse response = await mediator.Send(command, context.CancellationToken);

                UpdateEntityCounterQueryResponse result = UpdateCounterQueryInternalResponseConverter.ToDto(response);

                return result;
            });
    }
}
