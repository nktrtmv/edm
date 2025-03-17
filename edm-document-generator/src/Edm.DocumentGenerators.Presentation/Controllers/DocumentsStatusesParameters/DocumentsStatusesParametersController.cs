using Edm.DocumentGenerators.Application.DocumentsStatusesParameters.Queries.GetDefaultParametersByStatusType.Contracts;
using Edm.DocumentGenerators.GenericSubdomain.Tracing;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsStatusesParameters.Converters.Queries.GetDefaultParametersByStatusType;

using Grpc.Core;

using MediatR;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsStatusesParameters;

internal sealed class DocumentsStatusesParametersController : DocumentsStatusesParametersService.DocumentsStatusesParametersServiceBase
{
    public DocumentsStatusesParametersController(IMediator mediator, ILogger<DocumentsStatusesParametersController> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    private IMediator Mediator { get; }
    private ILogger<DocumentsStatusesParametersController> Logger { get; }

    public override async Task<GetDefaultDocumentsStatusesParametersByStatusTypeQueryResponse> GetDefaultParametersByStatusType(
        GetDefaultDocumentsStatusesParametersByStatusTypeQuery request,
        ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(GetDefaultParametersByStatusType),
            request,
            async () =>
            {
                var query = new GetDefaultDocumentsStatusesParametersByStatusTypeQueryInternal();

                GetDefaultDocumentsStatusesParametersByStatusTypeQueryInternalResponse response =
                    await Mediator.Send(query, context.CancellationToken);

                GetDefaultDocumentsStatusesParametersByStatusTypeQueryResponse result =
                    GetDefaultDocumentsStatusesParametersByStatusTypeQueryResponseConverter.FromInternal(response);

                return result;
            });
    }
}
