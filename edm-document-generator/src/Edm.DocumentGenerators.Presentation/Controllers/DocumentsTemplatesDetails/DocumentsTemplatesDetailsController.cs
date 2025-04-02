using Edm.DocumentGenerators.Application.DocumentsTemplatesDetails.Queries.GetDetails.Contracts;
using Edm.DocumentGenerators.GenericSubdomain.Tracing;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplatesDetails.Converters.Queries.GetDetails;

using Grpc.Core;

using MediatR;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplatesDetails;

internal sealed class DocumentsTemplatesDetailsController : DocumentsTemplatesDetailsService.DocumentsTemplatesDetailsServiceBase
{
    public DocumentsTemplatesDetailsController(IMediator mediator, ILogger<DocumentsTemplatesDetailsController> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    private IMediator Mediator { get; }
    private ILogger<DocumentsTemplatesDetailsController> Logger { get; }

    public override async Task<GetDetailsDocumentsTemplatesDetailsQueryResponse> GetDetails(GetDetailsDocumentsTemplatesDetailsQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(GetDetails),
            query,
            async () =>
            {
                GetDetailsDocumentsTemplatesDetailsQueryInternal request = GetDetailsDocumentsTemplatesDetailsQueryConverter.ToInternal(query);

                GetDetailsDocumentsTemplatesDetailsQueryInternalResponse response = await Mediator.Send(request, context.CancellationToken);

                GetDetailsDocumentsTemplatesDetailsQueryResponse result = GetDetailsDocumentsTemplatesDetailsQueryResponseConverter.FromInternal(response);

                return result;
            });
    }
}
