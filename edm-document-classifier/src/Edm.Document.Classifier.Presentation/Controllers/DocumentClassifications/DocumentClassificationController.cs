using Edm.Document.Classifier.Application.DocumentClassifications.Commands.Create.Contracts;
using Edm.Document.Classifier.Application.DocumentClassifications.Queries.Get.Contracts;
using Edm.Document.Classifier.Application.DocumentClassifications.Queries.Search.Contracts;
using Edm.Document.Classifier.GenericSubdomain.Tracing;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentClassifications.Converters.Commands.Create;
using Edm.Document.Classifier.Presentation.Controllers.DocumentClassifications.Converters.Queries.Get;
using Edm.Document.Classifier.Presentation.Controllers.DocumentClassifications.Converters.Queries.Search;

using Grpc.Core;

using MediatR;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentClassifications;

public sealed class DocumentClassificationController : DocumentClassificationService.DocumentClassificationServiceBase
{
    public DocumentClassificationController(IMediator mediator, ILogger<DocumentClassificationController> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    private IMediator Mediator { get; }
    private ILogger<DocumentClassificationController> Logger { get; }

    public override async Task<CreateDocumentClassificationCommandResponse> Create(CreateDocumentClassificationCommand command, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(Create),
            command,
            async () =>
            {
                CreateDocumentClassificationCommandInternal request = CreateDocumentClassificationCommandConverter.ToInternal(command);

                CreateDocumentClassificationCommandInternalResponse response = await Mediator.Send(request, context.CancellationToken);

                CreateDocumentClassificationCommandResponse result = CreateDocumentClassificationCommandResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task<GetDocumentClassificationQueryResponse> Get(GetDocumentClassificationQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(Get),
            query,
            async () =>
            {
                GetDocumentClassificationQueryInternal request = GetDocumentClassificationQueryConverter.ToInternal(query);

                GetDocumentClassificationQueryInternalResponse response = await Mediator.Send(request, context.CancellationToken);

                GetDocumentClassificationQueryResponse result = GetDocumentClassificationQueryResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task<SearchDocumentClassificationQueryResponse> Search(SearchDocumentClassificationQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(Search),
            query,
            async () =>
            {
                SearchDocumentClassificationQueryInternal request = SearchDocumentClassificationQueryConverter.ToInternal(query);

                SearchDocumentClassificationQueryInternalResponse response = await Mediator.Send(request, context.CancellationToken);

                SearchDocumentClassificationQueryResponse result = SearchDocumentClassificationQueryResponseConverter.FromInternal(response);

                return result;
            });
    }
}
