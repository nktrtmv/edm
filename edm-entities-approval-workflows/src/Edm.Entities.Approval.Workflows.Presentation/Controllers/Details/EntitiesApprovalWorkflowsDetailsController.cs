using Edm.Entities.Approval.Workflows.GenericSubdomain.Tracing;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetAllExecutors;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetCurrentExecutors;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows;

using Grpc.Core;

using MediatR;

using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetAllExecutors.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetCurrentExecutors.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Details;

internal sealed class EntitiesApprovalWorkflowsDetailsController : EntitiesApprovalWorkflowsDetailsService.EntitiesApprovalWorkflowsDetailsServiceBase
{
    public EntitiesApprovalWorkflowsDetailsController(IMediator mediator, ILogger<EntitiesApprovalWorkflowsDetailsController> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    private IMediator Mediator { get; }
    private ILogger<EntitiesApprovalWorkflowsDetailsController> Logger { get; }

    public override async Task<GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryResponseWorkflow> GetWorkflow(
        GetWorkflowsEntitiesApprovalWorkflowsDetailsQuery request,
        ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(GetWorkflow),
            request,
            async () =>
            {
                GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternal query =
                    GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryConverter.ToInternal(request);

                GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalResponseWorkflow response =
                    (await Mediator.Send(query, context.CancellationToken)).Workflows.First();

                GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryResponseWorkflow result =
                    GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryResponseWorkflowConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task GetWorkflows(
        GetWorkflowsEntitiesApprovalWorkflowsDetailsQuery request,
        IServerStreamWriter<GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryResponseWorkflow> responseStream,
        ServerCallContext context)
    {
        await TracingFacility.TraceGrpc(
            Logger,
            nameof(GetWorkflows),
            request,
            async () =>
            {
                GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternal query =
                    GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryConverter.ToInternal(request);

                GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalResponse response =
                    await Mediator.Send(query, context.CancellationToken);

                GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryResponseWorkflow[] workflows =
                    response.Workflows.Select(GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryResponseWorkflowConverter.FromInternal).ToArray();

                foreach (GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryResponseWorkflow workflow in workflows)
                {
                    await responseStream.WriteAsync(workflow);
                }

                return Task.CompletedTask;
            });
    }

    public override async Task<GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryResponse> GetAllExecutors(
        GetAllExecutorsEntitiesApprovalWorkflowsDetailsQuery request,
        ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(GetAllExecutors),
            request,
            async () =>
            {
                GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryInternal query =
                    GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryConverter.ToInternal(request);

                GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalResponse response =
                    await Mediator.Send(query, context.CancellationToken);

                GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryResponse result =
                    GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task<GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryResponse> GetCurrentExecutors(
        GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQuery request,
        ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(GetCurrentExecutors),
            request,
            async () =>
            {
                GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryInternal query =
                    GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryConverter.ToInternal(request);

                GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalResponse response =
                    await Mediator.Send(query, context.CancellationToken);

                GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryResponse result =
                    GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryResponseConverter.FromInternal(response);

                return result;
            });
    }
}
