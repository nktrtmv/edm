using Edm.Document.Classifier.Application.DocumentClassifiers.BusinessSegments.Queries.Get.Contracts;
using Edm.Document.Classifier.Application.DocumentClassifiers.DocumentCategories.Queries.Get.Contracts;
using Edm.Document.Classifier.Application.DocumentClassifiers.DocumentKinds.Queries.Get.Contracts;
using Edm.Document.Classifier.Application.DocumentClassifiers.DocumentTypes.Queries.Get.Contracts;
using Edm.Document.Classifier.GenericSubdomain.Tracing;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentClassifiers.Converters.Queries.GetBusinessSegments;
using Edm.Document.Classifier.Presentation.Controllers.DocumentClassifiers.Converters.Queries.GetDocumentCategories;
using Edm.Document.Classifier.Presentation.Controllers.DocumentClassifiers.Converters.Queries.GetDocumentKinds;
using Edm.Document.Classifier.Presentation.Controllers.DocumentClassifiers.Converters.Queries.GetDocumentTypes;

using Grpc.Core;

using MediatR;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentClassifiers;

public sealed class DocumentClassifierController : DocumentClassifierService.DocumentClassifierServiceBase
{
    public DocumentClassifierController(IMediator mediator, ILogger<DocumentClassifierController> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    private IMediator Mediator { get; }
    private ILogger<DocumentClassifierController> Logger { get; }

    public override async Task<GetBusinessSegmentsQueryResponse> GetBusinessSegments(GetBusinessSegmentsQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(GetBusinessSegments),
            query,
            async () =>
            {
                GetBusinessSegmentsQueryInternalResponse response = await Mediator.Send(new GetBusinessSegmentsQueryInternal(), context.CancellationToken);

                GetBusinessSegmentsQueryResponse result = GetBusinessSegmentsQueryResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task<GetDocumentCategoriesQueryResponse> GetDocumentCategories(GetDocumentCategoriesQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(GetDocumentCategories),
            query,
            async () =>
            {
                GetDocumentCategoriesQueryInternalResponse response = await Mediator.Send(new GetDocumentCategoriesQueryInternal(), context.CancellationToken);

                GetDocumentCategoriesQueryResponse result = GetDocumentCategoriesQueryResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task<GetDocumentTypesQueryResponse> GetDocumentTypes(GetDocumentTypesQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(GetDocumentTypes),
            query,
            async () =>
            {
                GetDocumentTypesQueryInternal request = GetDocumentTypesQueryConverter.ToInternal(query);

                GetDocumentTypesQueryInternalResponse response = await Mediator.Send(request, context.CancellationToken);

                GetDocumentTypesQueryResponse result = GetDocumentTypesQueryResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override async Task<GetDocumentKindsQueryResponse> GetDocumentKinds(GetDocumentKindsQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            Logger,
            nameof(GetDocumentKinds),
            query,
            async () =>
            {
                GetDocumentKindsQueryInternal request = GetDocumentKindsQueryConverter.ToInternal(query);

                GetDocumentKindsQueryInternalResponse response = await Mediator.Send(request, context.CancellationToken);

                GetDocumentKindsQueryResponse result = GetDocumentKindsQueryResponseConverter.FromInternal(response);

                return result;
            });
    }
}
