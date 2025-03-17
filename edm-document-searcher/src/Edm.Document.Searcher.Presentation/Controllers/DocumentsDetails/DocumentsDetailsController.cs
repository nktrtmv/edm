using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts;
using Edm.Document.Searcher.GenericSubdomain.Tracing;
using Edm.Document.Searcher.Presentation.Abstractions;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters;

using Grpc.Core;

using MediatR;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails;

public sealed class DocumentsDetailsController(ILogger<DocumentsDetailsController> logger, IMediator mediator) : DocumentsDetailsService.DocumentsDetailsServiceBase
{
    public override async Task<GetStepperQueryResponse> GetStepper(GetStepperQuery request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(GetStepper),
            request,
            async () =>
            {
                GetStepperQueryInternal command = GetStepperQueryConverter.ToInternal(request);

                GetStepperQueryResponseInternal response = await mediator.Send(command, context.CancellationToken);

                GetStepperQueryResponse result = GetStepperQueryResponseConverter.FromInternal(response);

                return result;
            });
    }
}
