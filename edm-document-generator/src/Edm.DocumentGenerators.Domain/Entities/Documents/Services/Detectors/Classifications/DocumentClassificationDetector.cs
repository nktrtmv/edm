using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters.Inheritors.ByRoles.Inheritors.References;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Constants;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.DocumentsRoles;
using Edm.DocumentGenerators.Domain.ValueObjects.Classifications;
using Edm.DocumentGenerators.Domain.ValueObjects.Classifications.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Detectors.Classifications;

public static class DocumentClassificationDetector
{
    private static readonly DocumentReferenceAttributeValueSelector Category = new DocumentReferenceAttributeValueSelector(
        DocumentAttributeDocumentRole.DocumentCategory,
        DocumentAttributeReferenceTypes.DocumentCategory);

    private static readonly DocumentReferenceAttributeValueSelector Type = new DocumentReferenceAttributeValueSelector(
        DocumentAttributeDocumentRole.DocumentType,
        DocumentAttributeReferenceTypes.DocumentType);

    private static readonly DocumentReferenceAttributeValueSelector Kind = new DocumentReferenceAttributeValueSelector(
        DocumentAttributeDocumentRole.DocumentKind,
        DocumentAttributeReferenceTypes.DocumentKind);

    private static readonly DocumentReferenceAttributeValueSelector Segment = new DocumentReferenceAttributeValueSelector(
        DocumentAttributeDocumentRole.BusinessSegment,
        DocumentAttributeReferenceTypes.BusinessSegment);

    public static DocumentClassification DetectRequired(DocumentAttributesValuesFetcher fetcher)
    {
        DocumentClassification? result = Detect(fetcher, true);

        return result!;
    }

    public static DocumentClassification? Detect(DocumentAttributesValuesFetcher fetcher, bool isRequired = false)
    {
        Id<BusinessSegment>? businessSegmentId =
            FetchSingleAttributeWithSingleValue<BusinessSegment>(fetcher, Segment);

        Id<DocumentCategory>? documentCategory =
            FetchSingleAttributeWithSingleValue<DocumentCategory>(fetcher, Category);

        Id<DocumentType>? documentType =
            FetchSingleAttributeWithSingleValue<DocumentType>(fetcher, Type);

        Id<DocumentKind>? documentKind =
            FetchSingleAttributeWithSingleValue<DocumentKind>(fetcher, Kind);

        if (isRequired)
        {
            Validate(businessSegmentId);
            Validate(documentCategory);
            Validate(documentType);
            Validate(documentKind);
        }

        if (businessSegmentId is null ||
            documentCategory is null ||
            documentType is null ||
            documentKind is null)
        {
            return null;
        }

        var result = new DocumentClassification(businessSegmentId, documentCategory, documentType, documentKind);

        return result;
    }

    private static Id<T>? FetchSingleAttributeWithSingleValue<T>(DocumentAttributesValuesFetcher fetcher, IDocumentAttributeValueSelector<string> selector)
    {
        string? value = fetcher.FetchSingleAttributeOrNullWithSingleValueOrNull(selector);

        Id<T>? result = NullableConverter.Convert(value, IdConverterFrom<T>.FromString);

        return result;
    }

    private static void Validate<T>(Id<T>? value)
    {
        if (value is null)
        {
            throw new BusinessLogicApplicationException($"Failed to detect Classification, Type: {typeof(T).Name}");
        }
    }
}
