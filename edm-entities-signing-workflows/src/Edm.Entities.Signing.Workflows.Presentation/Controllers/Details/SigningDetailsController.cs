using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Tracing;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetElectronicDetails;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetStages;

using Grpc.Core;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Details;

internal sealed class SigningDetailsController : SigningDetailsService.SigningDetailsServiceBase
{
    public SigningDetailsController(IMediator mediator, ILogger<SigningDetailsController> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    private IMediator Mediator { get; }
    private ILogger<SigningDetailsController> Logger { get; }

    public override async Task<GetSigningElectronicDetailsQueryResponse> GetElectronic(GetSigningElectronicDetailsQuery request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(GetElectronic),
            request,
            async () =>
            {
                GetSigningElectronicDetailsQueryInternal query = GetSigningElectronicDetailsQueryConverter.ToInternal(request);

                GetSigningElectronicDetailsQueryInternalResponse response = await Mediator.Send(query, context.CancellationToken);

                GetSigningElectronicDetailsQueryResponse result = GetSigningElectronicDetailsQueryResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task<GetSigningStagesDetailsQueryResponse> GetStages(GetSigningStagesDetailsQuery request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(GetStages),
            request,
            async () =>
            {
                GetSigningStagesDetailsQueryInternal query = GetSigningStagesDetailsQueryConverter.ToInternal(request);

                GetSigningStagesDetailsQueryInternalResponse response = await Mediator.Send(query, context.CancellationToken);

                GetSigningStagesDetailsQueryResponse result = GetSigningStagesDetailsQueryResponseConverter.FromInternal(response);

                return result;
            });
    }
}
