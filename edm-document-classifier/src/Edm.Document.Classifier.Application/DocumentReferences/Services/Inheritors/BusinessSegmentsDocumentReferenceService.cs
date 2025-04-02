using Edm.Document.Classifier.Application.DocumentReferences.Services.Services.Matchers;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.Markers;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.BusinessSegments;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.ReferenceKind;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.SearchKinds;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentClassifications;

using JetBrains.Annotations;

namespace Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors;

[UsedImplicitly]
internal sealed class BusinessSegmentsDocumentReferenceService(
    IDocumentClassifierRepository classifiersRepository,
    IDocumentClassificationRepository documentClassificationRepository)
    : DocumentReferenceService
{
    public override DocumentReferenceType Type { get; } = new DocumentReferenceType(
        DocumentReferenceTypeId.BusinessSegments,
        DocumentReferenceSearchKind.FixedList,
        DocumentReferenceKind.None,
        "Бизнес-сегменты");

    public override async Task<DocumentReferenceValue[]> Search(DocumentReferenceSearchParamsInternal searchParams, CancellationToken cancellationToken)
    {
        DocumentClassifier classifier = await classifiersRepository.Get(cancellationToken);

        var filteredSegments = classifier.BusinessSegments.AsEnumerable();

        if (searchParams.Ids.Length != 0)
        {
            filteredSegments = filteredSegments.Where(x => searchParams.Ids.Contains(x.Id.Value));
        }

        if (!string.IsNullOrWhiteSpace(searchParams.Search))
        {
            filteredSegments = filteredSegments.Where(v => QueryMatcher.ContainsQuery(searchParams.Search, v.Name));
        }

        var segments = filteredSegments.ToArray();

        if (segments.Length > 0 && !string.IsNullOrWhiteSpace(searchParams.Key.TemplateId))
        {
            var classificationIds = await GetClassificationFilteredIds(searchParams.Key.TemplateId, cancellationToken);
            segments = segments.Where(x => classificationIds.Contains(x.Id)).ToArray();
        }

        DocumentReferenceValue[] result = segments
            .Skip(searchParams.Skip)
            .Take(searchParams.Limit)
            .Select(MapBusinessSegment)
            .ToArray();

        return result;
    }

    private static DocumentReferenceValue MapBusinessSegment(BusinessSegment item)
    {
        return new DocumentReferenceValue(item.Id.ToString(), item.Name, string.Empty, item);
    }

    private async Task<HashSet<Id<BusinessSegment>>> GetClassificationFilteredIds(string templateId, CancellationToken cancellationToken)
    {
        Id<DocumentTemplate> documentTemplateId = IdConverterFrom<DocumentTemplate>.FromString(templateId);

        DocumentClassification classification = await documentClassificationRepository.GetRequired(documentTemplateId, cancellationToken);

        var results = classification.DocumentClassifierSubset.BusinessSegmentIds.ToHashSet();

        return results;
    }
}
