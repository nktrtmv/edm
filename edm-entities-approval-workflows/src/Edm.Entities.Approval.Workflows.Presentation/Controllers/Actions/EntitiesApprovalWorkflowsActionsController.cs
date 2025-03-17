using Edm.Entities.Approval.Workflows.GenericSubdomain.Tracing;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Actions.Converters.Commands.AddParticipant;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Actions.Converters.Commands.Complete;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Actions.Converters.Commands.Delegate;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Actions.Converters.Commands.TakeInWork;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Actions.Converters.Queries.GetAvailable;

using Grpc.Core;

using MediatR;

using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands.Inheritors.AddParticipant.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands.Inheritors.Complete.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands.Inheritors.Delegate.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands.Inheritors.TakeInWork.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Queries.GetAvailable.Contracts;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Actions;

internal sealed class EntitiesApprovalWorkflowsActionsController : EntitiesApprovalWorkflowsActionsService.EntitiesApprovalWorkflowsActionsServiceBase
{
    public EntitiesApprovalWorkflowsActionsController(IMediator mediator, ILogger<EntitiesApprovalWorkflowsActionsController> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    private IMediator Mediator { get; }
    private ILogger<EntitiesApprovalWorkflowsActionsController> Logger { get; }

    public override async Task<CompleteEntitiesApprovalWorkflowsActionsCommandResponse> Complete(
        CompleteEntitiesApprovalWorkflowsActionsCommand request,
        ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(Complete),
            request,
            async () =>
            {
                CompleteEntitiesApprovalWorkflowsActionsCommandInternal command =
                    CompleteEntitiesApprovalWorkflowsActionsCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new CompleteEntitiesApprovalWorkflowsActionsCommandResponse();
            });
    }

    public override async Task<AddParticipantEntitiesApprovalWorkflowsActionsCommandResponse> AddParticipant(
        AddParticipantEntitiesApprovalWorkflowsActionsCommand request,
        ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(AddParticipant),
            request,
            async () =>
            {
                AddParticipantEntitiesApprovalWorkflowsActionsCommandInternal command =
                    AddParticipantEntitiesApprovalWorkflowsActionsCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new AddParticipantEntitiesApprovalWorkflowsActionsCommandResponse();
            });
    }

    public override async Task<DelegateEntitiesApprovalWorkflowsActionsCommandResponse> Delegate(
        DelegateEntitiesApprovalWorkflowsActionsCommand request,
        ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(Delegate),
            request,
            async () =>
            {
                DelegateEntitiesApprovalWorkflowsActionsCommandInternal command =
                    DelegateEntitiesApprovalWorkflowsActionsCommandConverter.ToInternal(request);
                await Mediator.Send(command, context.CancellationToken);

                return new DelegateEntitiesApprovalWorkflowsActionsCommandResponse();
            });
    }

    public override async Task<TakeInWorkEntitiesApprovalWorkflowsActionsCommandResponse> TakeInWork(
        TakeInWorkEntitiesApprovalWorkflowsActionsCommand request,
        ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(TakeInWork),
            request,
            async () =>
            {
                TakeInWorkEntitiesApprovalWorkflowsActionsCommandInternal command =
                    TakeInWorkEntitiesApprovalWorkflowsActionsCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new TakeInWorkEntitiesApprovalWorkflowsActionsCommandResponse();
            });
    }

    public override async Task<GetAvailableEntitiesApprovalWorkflowsActionsQueryResponse> GetAvailable(
        GetAvailableEntitiesApprovalWorkflowsActionsQuery request,
        ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(GetAvailable),
            request,
            async () =>
            {
                GetAvailableEntitiesApprovalWorkflowsActionsQueryInternal query =
                    GetAvailableEntitiesApprovalWorkflowsActionsQueryConverter.ToInternal(request);

                GetAvailableEntitiesApprovalWorkflowsActionsQueryInternalResponse response =
                    await Mediator.Send(query, context.CancellationToken);

                GetAvailableEntitiesApprovalWorkflowsActionsQueryResponse result =
                    GetAvailableEntitiesApprovalWorkflowsActionsQueryResponseConverter.FromInternal(response);

                return result;
            });
    }
}
