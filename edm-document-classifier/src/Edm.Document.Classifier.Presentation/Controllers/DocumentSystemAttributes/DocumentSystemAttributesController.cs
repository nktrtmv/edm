using Edm.Document.Classifier.Application.DocumentSystemAttributes.Queries.GetAll.Contracts;
using Edm.Document.Classifier.GenericSubdomain.Tracing;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentSystemAttributes.Converters.Queries.GetAll;

using Grpc.Core;

using MediatR;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentSystemAttributes;

public sealed class DocumentSystemAttributesController : DocumentSystemAttributesService.DocumentSystemAttributesServiceBase
{
    public DocumentSystemAttributesController(IMediator mediator, ILogger<DocumentSystemAttributesController> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    private IMediator Mediator { get; }
    private ILogger<DocumentSystemAttributesController> Logger { get; }

    public override async Task<GetAllDocumentSystemAttributesQueryResponse> GetAll(GetAllDocumentSystemAttributesQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(GetAll),
            query,
            async () =>
            {
                GetAllDocumentSystemAttributesQueryInternal request = GetAllDocumentSystemAttributesQueryConverter.ToInternal(query);

                GetAllDocumentSystemAttributesQueryInternalResponse response = await Mediator.Send(request, context.CancellationToken);

                GetAllDocumentSystemAttributesQueryResponse result = GetAllDocumentSystemAttributesQueryResponseConverter.FromInternal(response);

                return result;
            });
    }
}
