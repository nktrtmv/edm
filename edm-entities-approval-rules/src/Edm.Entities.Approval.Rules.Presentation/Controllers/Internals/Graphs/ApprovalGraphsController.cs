using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Commands.Create.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Commands.Delete.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Commands.Update.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.Get.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.GetAll.Contracts;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tracing;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Commands.Create;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Commands.Delete;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Commands.Update;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Queries.Get;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Queries.GetAll;

using Grpc.Core;

using MediatR;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs;

internal sealed class ApprovalGraphsController : ApprovalGraphsService.ApprovalGraphsServiceBase
{
    public ApprovalGraphsController(IMediator mediator, ILogger<ApprovalGraphsController> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    private IMediator Mediator { get; }
    private ILogger<ApprovalGraphsController> Logger { get; }

    public override async Task<CreateApprovalGraphsCommandResponse> Create(CreateApprovalGraphsCommand command, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(Create),
            command,
            async () =>
            {
                CreateApprovalGraphsCommandInternal request = CreateApprovalGraphsCommandInternalConverter.FromDto(command);

                CreateApprovalGraphsCommandResponseInternal response = await Mediator.Send(request, context.CancellationToken);

                CreateApprovalGraphsCommandResponse result = CreateApprovalGraphsCommandResponseInternalConverter.ToDto(response);

                return result;
            });
    }

    public override async Task<DeleteApprovalGraphsCommandResponse> Delete(DeleteApprovalGraphsCommand command, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(Delete),
            command,
            async () =>
            {
                DeleteApprovalGraphsCommandInternal request = DeleteApprovalGraphsCommandInternalConverter.FromDto(command);

                await Mediator.Send(request, context.CancellationToken);

                return new DeleteApprovalGraphsCommandResponse();
            });
    }

    public override async Task<UpdateApprovalGraphsCommandResponse> Update(UpdateApprovalGraphsCommand command, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(Update),
            command,
            async () =>
            {
                UpdateApprovalGraphsCommandInternal request = UpdateApprovalGraphsCommandInternalConverter.FromDto(command);

                await Mediator.Send(request, context.CancellationToken);

                return new UpdateApprovalGraphsCommandResponse();
            });
    }

    public override async Task<GetApprovalGraphsQueryResponse> Get(GetApprovalGraphsQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(Get),
            query,
            async () =>
            {
                GetApprovalGraphsQueryInternal request = GetApprovalGraphsQueryInternalConverter.FromDto(query);

                GetApprovalGraphsQueryResponseInternal response = await Mediator.Send(request, context.CancellationToken);

                GetApprovalGraphsQueryResponse result = GetApprovalGraphsQueryResponseConverter.ToDto(response);

                return result;
            });
    }

    public override async Task<GetAllApprovalGraphsQueryResponse> GetAll(GetAllApprovalGraphsQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(GetAll),
            query,
            async () =>
            {
                GetAllApprovalGraphsQueryInternal request = GetAllApprovalGraphsQueryInternalConverter.FromDto(query);

                GetAllApprovalGraphsQueryResponseInternal response = await Mediator.Send(request, context.CancellationToken);

                GetAllApprovalGraphsQueryResponse result = GetAllApprovalGraphsQueryResponseInternalConverter.ToDto(response);

                return result;
            });
    }
}
