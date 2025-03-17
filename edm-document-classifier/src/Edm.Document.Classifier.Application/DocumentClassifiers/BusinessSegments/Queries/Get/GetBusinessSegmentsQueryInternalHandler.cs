using Edm.Document.Classifier.Application.DocumentClassifiers.BusinessSegments.Queries.Get.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.BusinessSegments;
using Edm.Document.Classifier.Domain.ValueObjects.Usages.Services.Selectors;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentClassifiers.BusinessSegments.Queries.Get;

[UsedImplicitly]
public class GetBusinessSegmentsQueryInternalHandler : IRequestHandler<GetBusinessSegmentsQueryInternal, GetBusinessSegmentsQueryInternalResponse>
{
    private readonly IDocumentClassifierRepository _documentClassifierRepository;

    public GetBusinessSegmentsQueryInternalHandler(IDocumentClassifierRepository documentClassifierRepository)
    {
        _documentClassifierRepository = documentClassifierRepository;
    }

    public async Task<GetBusinessSegmentsQueryInternalResponse> Handle(
        GetBusinessSegmentsQueryInternal request,
        CancellationToken cancellationToken)
    {
        DocumentClassifier classifier =
            await _documentClassifierRepository.Get(cancellationToken);

        BusinessSegment[] businessSegments =
            UsageSelector.Select(classifier.BusinessSegments, s => s.Usage);

        GetBusinessSegmentsQueryInternalResponse response =
            GetBusinessSegmentsQueryInternalResponseConverter.FromDomain(businessSegments);

        return response;
    }
}
