using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts;
using Edm.Document.Classifier.GenericSubdomain.Tracing;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Queries.GetTypes;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Queries.SearchValues;

using Grpc.Core;

using MediatR;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentReferences;

public sealed class DocumentReferencesController : DocumentReferencesService.DocumentReferencesServiceBase
{
    public DocumentReferencesController(IMediator mediator, ILogger<DocumentReferencesController> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    private IMediator Mediator { get; }
    private ILogger<DocumentReferencesController> Logger { get; }

    public override async Task<GetTypesDocumentReferencesQueryResponse> GetTypes(GetTypesDocumentReferencesQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(GetTypes),
            query,
            async () =>
            {
                var request = GetTypesDocumentReferencesQueryInternal.Instance;

                GetTypesDocumentReferencesQueryResponseInternal response = await Mediator.Send(request, context.CancellationToken);

                GetTypesDocumentReferencesQueryResponse result = GetTypesDocumentReferencesQueryResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task<SearchValuesDocumentReferencesQueryResponse> SearchValues(SearchValuesDocumentReferencesQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(SearchValues),
            query,
            async () =>
            {
                SearchValuesDocumentReferencesQueryInternal request = SearchValuesDocumentReferencesQueryConverter.ToInternal(query);

                SearchValuesDocumentReferencesQueryResponseInternal response = await Mediator.Send(request, context.CancellationToken);

                SearchValuesDocumentReferencesQueryResponse result = SearchValuesDocumentReferencesQueryResponseConverter.FromInternal(response);

                return result;
            });
    }
}
