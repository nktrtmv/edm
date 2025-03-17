using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.Cancel.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.PutIntoEffect.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.ReturnToRework.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.SendToContractor.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.Sign.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.WithdrawByContractor.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.WithdrawBySelf.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Queries.GetAvailableActions.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Queries.GetDocumentsToSign.Contracts;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Tracing;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Commands.Cancel;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Commands.PutIntoEffect;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Commands.ReturnToRework;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Commands.SendToContractor;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Commands.Sign;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Commands.WithdrawByContractor;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Commands.WithdrawBySelf;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Queries.GetAvailableActions;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Queries.GetDocumentsToSign;

using Grpc.Core;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions;

internal sealed class SigningActionsController : SigningActionsService.SigningActionsServiceBase
{
    public SigningActionsController(IMediator mediator, ILogger<SigningActionsController> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    private IMediator Mediator { get; }
    private ILogger<SigningActionsController> Logger { get; }

    public override async Task<CancelSigningActionCommandResponse> Cancel(CancelSigningActionCommand request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(Cancel),
            request,
            async () =>
            {
                CancelSigningActionCommandInternal command = CancelSigningActionCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                var result = new CancelSigningActionCommandResponse();

                return result;
            });
    }

    public override async Task<PutIntoEffectSigningActionCommandResponse> PutIntoEffect(PutIntoEffectSigningActionCommand request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(PutIntoEffect),
            request,
            async () =>
            {
                PutIntoEffectSigningActionCommandInternal command = PutIntoEffectSigningActionCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                var result = new PutIntoEffectSigningActionCommandResponse();

                return result;
            });
    }

    public override async Task<ReturnToReworkSigningActionCommandResponse> ReturnToRework(ReturnToReworkSigningActionCommand request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(ReturnToRework),
            request,
            async () =>
            {
                ReturnToReworkSigningActionCommandInternal command = ReturnToReworkSigningActionCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                var result = new ReturnToReworkSigningActionCommandResponse();

                return result;
            });
    }

    public override async Task<SendToContractorSigningActionCommandResponse> SendToContractor(SendToContractorSigningActionCommand request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(SendToContractor),
            request,
            async () =>
            {
                SendToContractorSigningActionCommandInternal command = SendToContractorSigningActionCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                var result = new SendToContractorSigningActionCommandResponse();

                return result;
            });
    }

    public override async Task<SignSigningActionCommandResponse> Sign(SignSigningActionCommand request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(Sign),
            request,
            async () =>
            {
                SignSigningActionCommandInternal command = SignSigningActionCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                var result = new SignSigningActionCommandResponse();

                return result;
            });
    }

    public override async Task<WithdrawByContractorSigningActionCommandResponse> WithdrawByContractor(
        WithdrawByContractorSigningActionCommand request,
        ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(WithdrawByContractor),
            request,
            async () =>
            {
                WithdrawByContractorSigningActionCommandInternal command = WithdrawByContractorSigningActionCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                var result = new WithdrawByContractorSigningActionCommandResponse();

                return result;
            });
    }

    public override async Task<WithdrawBySelfSigningActionCommandResponse> WithdrawBySelf(WithdrawBySelfSigningActionCommand request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(WithdrawBySelf),
            request,
            async () =>
            {
                WithdrawBySelfSigningActionCommandInternal command = WithdrawBySelfSigningActionCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                var result = new WithdrawBySelfSigningActionCommandResponse();

                return result;
            });
    }

    public override async Task<GetAvailableSigningActionsQueryResponse> GetAvailableActions(GetAvailableSigningActionsQuery request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(GetAvailableActions),
            request,
            async () =>
            {
                GetAvailableSigningActionsQueryInternal query = GetAvailableSigningActionsQueryConverter.ToInternal(request);

                GetAvailableSigningActionsQueryInternalResponse response = await Mediator.Send(query, context.CancellationToken);

                GetAvailableSigningActionsQueryResponse result = GetAvailableSigningActionsQueryResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task<GetSigningDocumentsToSignQueryResponse> GetDocumentsToSign(GetSigningDocumentsToSignQuery request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(GetDocumentsToSign),
            request,
            async () =>
            {
                GetSigningDocumentsToSignQueryInternal query = GetSigningDocumentsToSignQueryConverter.ToInternal(request);

                GetSigningDocumentsToSignQueryInternalResponse response = await Mediator.Send(query, context.CancellationToken);

                GetSigningDocumentsToSignQueryResponse result = GetSigningDocumentsToSignQueryResponseConverter.FromInternal(response);

                return result;
            });
    }
}
