using System.Text.Json;

using Edm.Entities.Approval.Rules.Application.External.Rules.Commands.DeleteEntityType.Contracts;
using Edm.Entities.Approval.Rules.Application.External.Rules.Commands.UpsertEntityType.Contracts;
using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts;
using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.ValidateThereAreActiveGraphs.Contracts;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tracing;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Commands.DeleteEntityType;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Commands.UpsertEntityType;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Queries.FindRoute;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Queries.ValidateThereAreActiveGraphs;

using Grpc.Core;

using MediatR;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules;

internal sealed class ApprovalRulesExternalController(IMediator mediator, ILogger<ApprovalRulesExternalController> logger)
    : ApprovalRulesService.ApprovalRulesServiceBase
{
    public override async Task<UpsertEntityTypeApprovalRulesCommandResponse> UpsertEntityType(
        UpsertEntityTypeApprovalRulesCommand command,
        ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(UpsertEntityType),
            command,
            async () =>
            {
                UpsertEntityTypeApprovalRulesCommandInternal request = UpsertEntityTypeApprovalRulesCommandInternalConverter.FromDto(command);

                await mediator.Send(request, context.CancellationToken);

                var result = new UpsertEntityTypeApprovalRulesCommandResponse();

                return result;
            });
    }

    public override async Task<DeleteEntityTypeApprovalRulesCommandResponse> DeleteEntityType(
        DeleteEntityTypeApprovalRulesCommand command,
        ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(DeleteEntityType),
            command,
            async () =>
            {
                DeleteEntityTypeApprovalRulesCommandInternal request = DeleteEntityTypeApprovalRulesCommandInternalConverter.FromDto(command);

                await mediator.Send(request, context.CancellationToken);

                var result = new DeleteEntityTypeApprovalRulesCommandResponse();

                return result;
            });
    }

    public override async Task<FindRouteApprovalRulesQueryResponse> FindRoute(
        FindRouteApprovalRulesQuery query,
        ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(FindRoute),
            query,
            async () =>
            {
                FindRouteApprovalRulesQueryInternal request = FindRouteApprovalRulesQueryInternalConverter.FromDto(query);

                FindRouteApprovalRulesQueryResponseInternal response = await mediator.Send(request, context.CancellationToken);

                FindRouteApprovalRulesQueryResponse result = FindRouteApprovalRulesQueryResponseInternalConverter.ToDto(response);

                string resultJson = JsonSerializer.Serialize(result);

                logger.LogInformation("ROUTE RESULT: 🔎🔎🔎🔎🔎\n{Route}", resultJson);
                logger.LogInformation("ROUTE RESULT-8: 🔎🔎🔎🔎🔎\n{@Route}", result);
                logger.LogInformation("ROUTE RESULT-STAGES: 🔎🔎🔎🔎🔎\n{@Route}", result.Route.Stages);

                return result;
            });
    }

    public override async Task<ValidateThereAreActiveGraphsApprovalRulesQueryResponse> ValidateThereAreActiveGraphs(
        ValidateThereAreActiveGraphsApprovalRulesQuery query,
        ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(ValidateThereAreActiveGraphs),
            query,
            async () =>
            {
                ValidateThereAreActiveGraphsApprovalRulesQueryInternal request = ValidateThereAreActiveGraphsApprovalRulesQueryInternalConverter.FromDto(query);

                await mediator.Send(request, context.CancellationToken);

                var result = new ValidateThereAreActiveGraphsApprovalRulesQueryResponse();

                return result;
            });
    }
}
