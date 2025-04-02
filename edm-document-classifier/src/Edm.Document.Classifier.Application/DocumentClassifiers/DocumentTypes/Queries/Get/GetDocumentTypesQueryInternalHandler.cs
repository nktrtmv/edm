using Edm.Document.Classifier.Application.DocumentClassifiers.DocumentTypes.Queries.Get.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes;
using Edm.Document.Classifier.Domain.ValueObjects.Usages.Services.Selectors;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentClassifiers.DocumentTypes.Queries.Get;

[UsedImplicitly]
internal sealed class GetDocumentTypesQueryInternalHandler : IRequestHandler<GetDocumentTypesQueryInternal, GetDocumentTypesQueryInternalResponse>
{
    public GetDocumentTypesQueryInternalHandler(IDocumentClassifierRepository classifier)
    {
        Classifier = classifier;
    }

    private IDocumentClassifierRepository Classifier { get; }

    public async Task<GetDocumentTypesQueryInternalResponse> Handle(GetDocumentTypesQueryInternal request, CancellationToken cancellationToken)
    {
        DocumentClassifier classifier = await Classifier.Get(cancellationToken);

        Id<DocumentCategory> documentCategoryId = IdConverterFrom<DocumentCategory>.FromString(request.DocumentCategoryId);

        DocumentCategory documentCategory = classifier.DocumentCategories
            .Single(d => d.Id == documentCategoryId);

        DocumentType[] documentTypes =
            UsageSelector.Select(documentCategory.DocumentTypes, t => t.Usage);

        GetDocumentTypesQueryInternalResponse response =
            GetDocumentCategoriesQueryInternalResponseConverter.FromDomain(documentTypes);

        return response;
    }
}
