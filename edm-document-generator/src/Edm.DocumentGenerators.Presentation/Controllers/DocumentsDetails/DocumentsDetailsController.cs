using Edm.DocumentGenerators.Application.DocumentsDetails.Queries.GetDocumentsNumbers.Contracts;
using Edm.DocumentGenerators.Application.DocumentsDetails.Queries.GetDocumentsReferenceDetails.Contracts;
using Edm.DocumentGenerators.GenericSubdomain.Tracing;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsDetails.Converters.Queries.GetDocumentsNumbers;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsDetails.Converters.Queries.GetDocumentsReferenceDetails;

using Grpc.Core;

using MediatR;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsDetails;

internal sealed class DocumentsDetailsController : DocumentsDetailsService.DocumentsDetailsServiceBase
{
    public DocumentsDetailsController(IMediator mediator, ILogger<DocumentsDetailsController> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    private IMediator Mediator { get; }
    private ILogger<DocumentsDetailsController> Logger { get; }

    public override async Task<GetDocumentsReferenceDetailsQueryResponse> GetReferenceDetails(GetDocumentsReferenceDetailsQuery request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(GetReferenceDetails),
            request,
            async () =>
            {
                GetDocumentsReferenceDetailsQueryInternal query = GetDocumentsReferenceDetailsQueryConverter.ToInternal(request);

                GetDocumentsReferenceDetailsQueryInternalResponse response = await Mediator.Send(query, context.CancellationToken);

                GetDocumentsReferenceDetailsQueryResponse result = GetDocumentsReferenceDetailsQueryResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task<GetDocumentRegistrationNumberQueryResponse> GetRegistrationNumber(GetDocumentRegistrationNumberQuery request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(GetRegistrationNumber),
            request,
            async () =>
            {
                GetDocumentRegistrationNumberQueryInternal query = GetDocumentRegistrationNumberQueryConverter.ToInternal(request);

                GetDocumentRegistrationNumberQueryInternalResponse response = await Mediator.Send(query, context.CancellationToken);

                GetDocumentRegistrationNumberQueryResponse result = GetDocumentRegistrationNumberQueryResponseConverter.FromInternal(response);

                return result;
            });
    }
}
