using Edm.Document.Classifier.Application.DocumentReferences.Services.Services.Matchers;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.ReferenceKind;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.SearchKinds;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentClassifications;

using JetBrains.Annotations;

namespace Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors.Classifications.Inheritors.Categories;

[UsedImplicitly]
internal sealed class DocumentCategoriesDocumentReferenceService(
    IDocumentClassificationRepository classificationsRepository,
    IDocumentClassifierRepository classifiersRepository)
    : DocumentClassificationDocumentReferenceService(classificationsRepository, classifiersRepository)
{
    public override DocumentReferenceType Type { get; } = new DocumentReferenceType(
        DocumentReferenceTypeId.DocumentCategories,
        DocumentReferenceSearchKind.FixedList,
        DocumentReferenceKind.None,
        "Категории документов");

    public override async Task<DocumentReferenceValue[]> Search(DocumentReferenceSearchParamsInternal searchParams, CancellationToken cancellationToken)
    {
        DocumentClassifier classifier = await ClassifiersRepository.Get(cancellationToken);

        DocumentCategory[] categories;

        if (string.IsNullOrWhiteSpace(searchParams.Key.TemplateId))
        {
            categories = classifier.DocumentCategories.ToArray();
        }
        else
        {
            var classification = await GetClassification(searchParams.Key.TemplateId, cancellationToken);

            var category = classifier.DocumentCategories.FirstOrDefault(x => x.Id == classification.DocumentClassifierSubset.DocumentCategory.Id);

            if (category == null)
            {
                categories = [];
            }
            else
            {
                categories = [category];
            }
        }

        DocumentReferenceValue[] results = categories
            .Where(x => searchParams.Ids.Length == 0 || searchParams.Ids.Contains(x.Id.Value))
            .Where(c => QueryMatcher.ContainsNullOrEmptyQuery(searchParams.Search, c.Name))
            .Skip(searchParams.Skip)
            .Take(searchParams.Limit)
            .Select(CreateReferenceValue)
            .ToArray();

        return results;
    }

    private static DocumentReferenceValue CreateReferenceValue(DocumentCategory category)
    {
        var id = IdConverterTo.ToString(category.Id);

        var result = new DocumentReferenceValue(id, category.Name, string.Empty, category);

        return result;
    }
}
