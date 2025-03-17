using Edm.Document.Classifier.Application.DocumentClassifiers.DocumentCategories.Queries.Get.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories;
using Edm.Document.Classifier.Domain.ValueObjects.Usages.Services.Selectors;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentClassifiers.DocumentCategories.Queries.Get;

[UsedImplicitly]
internal sealed class GetDocumentCategoriesQueryInternalHandler : IRequestHandler<GetDocumentCategoriesQueryInternal, GetDocumentCategoriesQueryInternalResponse>
{
    private readonly IDocumentClassifierRepository _documentClassifierRepository;

    public GetDocumentCategoriesQueryInternalHandler(IDocumentClassifierRepository documentClassifierRepository)
    {
        _documentClassifierRepository = documentClassifierRepository;
    }

    public async Task<GetDocumentCategoriesQueryInternalResponse> Handle(GetDocumentCategoriesQueryInternal request, CancellationToken cancellationToken)
    {
        DocumentClassifier classifier =
            await _documentClassifierRepository.Get(cancellationToken);

        DocumentCategory[] documentCategories =
            UsageSelector.Select(classifier.DocumentCategories, c => c.Usage);

        GetDocumentCategoriesQueryInternalResponse response =
            GetDocumentCategoriesQueryInternalResponseConverter.FromDomain(documentCategories);

        return response;
    }
}
