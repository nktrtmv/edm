using Edm.Entities.Approval.Rules.Application.Internal.Groups.Commands.Create.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Commands.Delete.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Commands.Update.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.Get.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.GetAll.Contracts;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tracing;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Commands.Create;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Commands.Delete;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Commands.Update;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Queries.Get;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Queries.GetAll;

using Grpc.Core;

using MediatR;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups;

internal sealed class ApprovalGroupsController : ApprovalGroupsService.ApprovalGroupsServiceBase
{
    public ApprovalGroupsController(ILogger<ApprovalGroupsController> logger, IMediator mediator)
    {
        Logger = logger;
        Mediator = mediator;
    }

    private IMediator Mediator { get; }
    private ILogger<ApprovalGroupsController> Logger { get; }

    public override async Task<CreateApprovalGroupsCommandResponse> Create(CreateApprovalGroupsCommand command, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(Create),
            command,
            async () =>
            {
                CreateApprovalGroupsCommandInternal request = CreateApprovalGroupsCommandInternalConverter.FromDto(command);

                CreateApprovalGroupsCommandResponseInternal response = await Mediator.Send(request, context.CancellationToken);

                CreateApprovalGroupsCommandResponse result = CreateApprovalGroupsCommandResponseInternalConverter.ToDto(response);

                return result;
            });
    }

    public override async Task<DeleteApprovalGroupsCommandResponse> Delete(DeleteApprovalGroupsCommand command, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(Delete),
            command,
            async () =>
            {
                DeleteApprovalGroupsCommandInternal request = DeleteApprovalGroupsCommandInternalConverter.FromDto(command);

                await Mediator.Send(request, context.CancellationToken);

                return new DeleteApprovalGroupsCommandResponse();
            });
    }

    public override async Task<UpdateApprovalGroupsCommandResponse> Update(UpdateApprovalGroupsCommand command, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(Update),
            command,
            async () =>
            {
                UpdateApprovalGroupsCommandInternal request = UpdateApprovalGroupsCommandInternalConverter.FromDto(command);

                await Mediator.Send(request, context.CancellationToken);

                return new UpdateApprovalGroupsCommandResponse();
            });
    }

    public override async Task<GetApprovalGroupsQueryResponse> Get(GetApprovalGroupsQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(Get),
            query,
            async () =>
            {
                GetApprovalGroupsQueryInternal request = GetApprovalGroupsQueryInternalConverter.FromDto(query);

                GetApprovalGroupsQueryResponseInternal response = await Mediator.Send(request, context.CancellationToken);

                GetApprovalGroupsQueryResponse result = GetApprovalGroupsQueryResponseInternalConverter.ToDto(response);

                return result;
            });
    }

    public override async Task<GetAllApprovalGroupsQueryResponse> GetAll(GetAllApprovalGroupsQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(GetAll),
            query,
            async () =>
            {
                GetAllApprovalGroupsQueryInternal request = GetAllApprovalGroupsQueryInternalConverter.FromDto(query);

                GetAllApprovalGroupsQueryResponseInternal response = await Mediator.Send(request, context.CancellationToken);

                GetAllApprovalGroupsQueryResponse result = GetAllApprovalGroupsQueryResponseInternalConverter.ToDto(response);

                return result;
            });
    }
}
