using Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors.Classifications.Services;
using Edm.Document.Classifier.Application.DocumentReferences.Services.Services.Matchers;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes.DocumentKinds;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.ReferenceKind;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.SearchKinds;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentClassifications;

using JetBrains.Annotations;

namespace Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors.Classifications.Inheritors.Kinds;

[UsedImplicitly]
internal sealed class DocumentKindsDocumentReferenceService(
    IDocumentClassificationRepository classificationsRepository,
    IDocumentClassifierRepository classifiersRepository)
    : DocumentClassificationDocumentReferenceService(classificationsRepository, classifiersRepository)
{
    public override DocumentReferenceType Type { get; } = new DocumentReferenceType(
        DocumentReferenceTypeId.DocumentKinds,
        DocumentReferenceSearchKind.Search,
        DocumentReferenceKind.None,
        "Виды документов",
        DocumentReferenceTypeId.DocumentTypes,
        DocumentReferenceTypeId.DocumentCategories);

    public override async Task<DocumentReferenceValue[]> Search(DocumentReferenceSearchParamsInternal searchParams, CancellationToken cancellationToken)
    {
        DocumentClassifier classifier = await ClassifiersRepository.Get(cancellationToken);

        (DocumentCategory Category, DocumentKind Kind)[] kinds;

        if (string.IsNullOrWhiteSpace(searchParams.Key.TemplateId))
        {
            kinds = classifier.DocumentCategories
                .SelectMany(x => x.DocumentTypes.SelectMany(t => t.DocumentKinds).Select(y => (x, y)))
                .ToArray();
        }
        else
        {
            var classification = await GetClassification(searchParams.Key.TemplateId, cancellationToken);

            var category = classifier.DocumentCategories.FirstOrDefault(x => x.Id == classification.DocumentClassifierSubset.DocumentCategory.Id);

            if (category == null)
            {
                kinds = [];
            }
            else
            {
                var parentDocumentTypesIds =
                    SearchParametersFilterFactory.CreateParentReferenceIdsFilter<DocumentType>(searchParams, DocumentReferenceTypeId.DocumentTypes);

                var subsetDocumentKindsIds = classification.DocumentClassifierSubset.DocumentCategory.DocumentTypes
                    .SelectMany(x => x.DocumentKindIds)
                    .ToHashSet();

                kinds = classifier.DocumentCategories
                    .SelectMany(x => x.DocumentTypes)
                    .Where(x => parentDocumentTypesIds.Count == 0 || parentDocumentTypesIds.Contains(x.Id))
                    .SelectMany(x => x.DocumentKinds)
                    .Where(x => subsetDocumentKindsIds.Contains(x.Id))
                    .Select(kind => (category, kind))
                    .ToArray();
            }
        }

        DocumentReferenceValue[] result = kinds
            .Where(k => searchParams.Ids.Length == 0 || searchParams.Ids.Contains(k.Kind.Id.Value))
            .Where(k => QueryMatcher.ContainsNullOrEmptyQuery(searchParams.Search, k.Kind.Name))
            .Skip(searchParams.Skip)
            .Take(searchParams.Limit)
            .Select(k => CreateReferenceValue(k.Kind, k.Category))
            .ToArray();

        return result;
    }

    private static DocumentReferenceValue CreateReferenceValue(DocumentKind kind, DocumentCategory category)
    {
        DocumentType type = category.DocumentTypes.Single(t => t.DocumentKinds.Any(k => k.Id == kind.Id));

        var id = IdConverterTo.ToString(kind.Id);

        string displayValue = kind.Name;

        var displaySubValue = $"{category.Name} / {type.Name}";

        var result = new DocumentReferenceValue(id, displayValue, displaySubValue, kind);

        return result;
    }
}
