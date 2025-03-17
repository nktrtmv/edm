using Edm.Document.Classifier.Application.DocumentClassifiers.DocumentKinds.Queries.Get.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes.DocumentKinds;
using Edm.Document.Classifier.Domain.ValueObjects.Usages.Services.Selectors;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentClassifiers.DocumentKinds.Queries.Get;

[UsedImplicitly]
internal sealed class GetDocumentKindsQueryInternalHandler : IRequestHandler<GetDocumentKindsQueryInternal, GetDocumentKindsQueryInternalResponse>
{
    private readonly IDocumentClassifierRepository _documentClassifierRepository;

    public GetDocumentKindsQueryInternalHandler(IDocumentClassifierRepository documentClassifierRepository)
    {
        _documentClassifierRepository = documentClassifierRepository;
    }

    public async Task<GetDocumentKindsQueryInternalResponse> Handle(GetDocumentKindsQueryInternal request, CancellationToken cancellationToken)
    {
        DocumentClassifier classifier = await _documentClassifierRepository.Get(cancellationToken);

        Id<DocumentCategory> documentCategoryId = IdConverterFrom<DocumentCategory>.FromString(request.DocumentCategoryId);
        Id<DocumentType> documentTypeId = IdConverterFrom<DocumentType>.FromString(request.DocumentTypeId);

        DocumentCategory category = classifier.DocumentCategories.Single(d => d.Id == documentCategoryId);
        DocumentType type = category.DocumentTypes.Single(d => d.Id == documentTypeId);

        DocumentKind[] documentKinds =
            UsageSelector.Select(type.DocumentKinds, k => k.Usage);

        GetDocumentKindsQueryInternalResponse result =
            GetDocumentKindsQueryInternalResponseConverter.FromDomain(documentKinds);

        return result;
    }
}
