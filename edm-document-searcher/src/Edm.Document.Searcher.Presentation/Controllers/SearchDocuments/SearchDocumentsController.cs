using Edm.Document.Searcher.Application.Documents.Command;
using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts;
using Edm.Document.Searcher.Application.Documents.Queries.Search.Contracts;
using Edm.Document.Searcher.GenericSubdomain.Tracing;
using Edm.Document.Searcher.Presentation.Abstractions;
using Edm.Document.Searcher.Presentation.Controllers.SearchDocuments.Converters.Queries.Get.Queries;
using Edm.Document.Searcher.Presentation.Controllers.SearchDocuments.Converters.Queries.Get.Responses.Documents;
using Edm.Document.Searcher.Presentation.Controllers.SearchDocuments.Converters.Queries.Search;

using Grpc.Core;

using MediatR;

namespace Edm.Document.Searcher.Presentation.Controllers.SearchDocuments;

internal sealed class SearchDocumentsController(ILogger<SearchDocumentsController> logger, IMediator mediator) : SearchDocumentsService.SearchDocumentsServiceBase
{
    public override async Task Get(GetDocumentsQuery request, IServerStreamWriter<GetDocumentsQueryResponseSearchDocument> responseStream, ServerCallContext context)
    {
        await TracingFacility.TraceGrpc(
            logger,
            nameof(Get),
            request,
            async () =>
            {
                GetDocumentsQueryInternal command = GetDocumentsQueryConverter.ToInternal(request);

                GetDocumentsQueryInternalResponse response = await mediator.Send(command, context.CancellationToken);

                GetDocumentsQueryResponseSearchDocument[] documents =
                    response.Documents.Select(GetDocumentsQueryResponseSearchDocumentConverter.FromInternal).ToArray();

                foreach (GetDocumentsQueryResponseSearchDocument document in documents)
                {
                    await responseStream.WriteAsync(document);
                }

                return Task.CompletedTask;
            });
    }

    public override async Task<SearchDocumentsQueryResponse> Search(SearchDocumentsQuery request, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(Search),
            request,
            async () =>
            {
                SearchDocumentsQueryInternal command = SearchDocumentsQueryConverter.ToInternal(request);

                SearchDocumentsQueryInternalResponse response = await mediator.Send(command, context.CancellationToken);

                SearchDocumentsQueryResponse result = SearchDocumentsQueryResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task<DeleteDocumentsCommandResponse> Delete(DeleteDocumentsCommand request, ServerCallContext context)
    {
        var requestInternal = new DeleteDocumentsCommandInternal(request.DomainId, request.DocumentIds.ToArray());

        await mediator.Send(requestInternal, context.CancellationToken);

        return new DeleteDocumentsCommandResponse();
    }
}
