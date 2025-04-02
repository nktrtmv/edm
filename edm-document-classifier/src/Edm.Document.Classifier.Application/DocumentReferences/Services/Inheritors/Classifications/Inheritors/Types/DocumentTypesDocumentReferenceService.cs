using Edm.Document.Classifier.Application.DocumentReferences.Services.Services.Matchers;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.ReferenceKind;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.SearchKinds;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values;
using Edm.Document.Classifier.Domain.ValueObjects.Usages.Services.Selectors;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentClassifications;

using JetBrains.Annotations;

namespace Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors.Classifications.Inheritors.Types;

[UsedImplicitly]
internal sealed class DocumentTypesDocumentReferenceService(
    IDocumentClassificationRepository classificationsRepository,
    IDocumentClassifierRepository classifiersRepository)
    : DocumentClassificationDocumentReferenceService(classificationsRepository, classifiersRepository)
{
    public override DocumentReferenceType Type { get; } = new DocumentReferenceType(
        DocumentReferenceTypeId.DocumentTypes,
        DocumentReferenceSearchKind.Search,
        DocumentReferenceKind.None,
        "Типы документов",
        DocumentReferenceTypeId.DocumentCategories);

    public override async Task<DocumentReferenceValue[]> Search(DocumentReferenceSearchParamsInternal searchParams, CancellationToken cancellationToken)
    {
        DocumentClassifier classifier = await ClassifiersRepository.Get(cancellationToken);

        (DocumentCategory Category, DocumentType Type)[] types;
        var templateId = searchParams.Key.TemplateId;

        if (string.IsNullOrWhiteSpace(templateId))
        {
            types = classifier.DocumentCategories
                .SelectMany(category => category.DocumentTypes.Select(type => (category, type)))
                .ToArray();
        }
        else
        {
            var classification = await GetClassification(searchParams.Key.TemplateId, cancellationToken);

            var subsetDocumentTypesIds = classification.DocumentClassifierSubset.DocumentCategory.DocumentTypes.Select(x => x.DocumentTypeId).ToHashSet();

            types = classifier.DocumentCategories
                .SelectMany(category => category.DocumentTypes.Where(type => subsetDocumentTypesIds.Contains(type.Id)).Select(type => (category, type)))
                .ToArray();
        }

        types = UsageSelector.Select(types, t => t.Category.Usage);

        DocumentReferenceValue[] result = types
            .Where(t => searchParams.Ids.Length == 0 || searchParams.Ids.Contains(t.Type.Id.Value))
            .Where(t => QueryMatcher.ContainsNullOrEmptyQuery(searchParams.Search, t.Type.Name))
            .Skip(searchParams.Skip)
            .Take(searchParams.Limit)
            .Select(t => CreateReferenceValue(t.Type, t.Category))
            .ToArray();

        return result;
    }

    private static DocumentReferenceValue CreateReferenceValue(DocumentType type, DocumentCategory category)
    {
        var id = IdConverterTo.ToString(type.Id);

        string displayValue = type.Name;

        var displaySubValue = $"{category.Name}";

        var result = new DocumentReferenceValue(id, displayValue, displaySubValue, type);

        return result;
    }
}
