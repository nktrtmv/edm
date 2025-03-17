using Edm.Entities.Approval.Rules.Application.Internal.Conditions.Operators.Queries.GetAttributesOperators.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Conditions.Operators.Queries.GetLogicalOperators.Contracts;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tracing;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Conditions.Operators.Converters.Queries.GetAttributesOperators;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Conditions.Operators.Converters.Queries.GetLogicalOperators;

using Grpc.Core;

using MediatR;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Conditions.Operators;

internal sealed class ApprovalConditionsOperatorsController : ApprovalConditionsOperatorsService.ApprovalConditionsOperatorsServiceBase
{
    public ApprovalConditionsOperatorsController(IMediator mediator, ILogger<ApprovalConditionsOperatorsController> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    private IMediator Mediator { get; }
    private ILogger<ApprovalConditionsOperatorsController> Logger { get; }

    public override async Task<GetAttributesOperatorsApprovalConditionsOperatorsQueryResponse> GetAttributesOperators(
        GetAttributesOperatorsApprovalConditionsOperatorsQuery query,
        ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(GetAttributesOperators),
            query,
            async () =>
            {
                GetAttributesOperatorsApprovalConditionsOperatorsQueryInternal request =
                    GetAttributesOperatorsApprovalConditionsOperatorsQueryInternalConverter.FromDto(query);

                GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseInternal response =
                    await Mediator.Send(request, context.CancellationToken);

                GetAttributesOperatorsApprovalConditionsOperatorsQueryResponse result =
                    GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseInternalConverter.ToDto(response);

                return result;
            });
    }

    public override async Task<GetLogicalOperatorsApprovalConditionsOperatorsQueryResponse> GetLogicalOperators(
        GetLogicalOperatorsApprovalConditionsOperatorsQuery query,
        ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(GetLogicalOperators),
            query,
            async () =>
            {
                var request = new GetLogicalOperatorsApprovalConditionsOperatorsQueryInternal();

                GetLogicalOperatorsApprovalConditionsOperatorsQueryResponseInternal response =
                    await Mediator.Send(request, context.CancellationToken);

                GetLogicalOperatorsApprovalConditionsOperatorsQueryResponse result =
                    GetLogicalOperatorsApprovalConditionsOperatorsQueryResponseInternalConverter.ToDto(response);

                return result;
            });
    }
}
