using Edm.DocumentGenerators.Domain.Entities.Documents.Factories.CreationContext;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Constants;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Services.Selectors.Reference;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.DocumentsRoles;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Custom.Classifications;

internal sealed class ClassificationDocumentAttributeValueFactory : IDocumentAttributeValueFactory
{
    private ReferenceDocumentAttributeSelector BusinessSegment { get; } = new ReferenceDocumentAttributeSelector
    {
        ReferenceType = DocumentAttributeReferenceTypes.BusinessSegment,
        Role = (int)DocumentAttributeDocumentRole.BusinessSegment
    };

    private ReferenceDocumentAttributeSelector DocumentCategory { get; } = new ReferenceDocumentAttributeSelector
    {
        ReferenceType = DocumentAttributeReferenceTypes.DocumentCategory,
        Role = (int)DocumentAttributeDocumentRole.DocumentCategory
    };

    private ReferenceDocumentAttributeSelector DocumentType { get; } = new ReferenceDocumentAttributeSelector
    {
        ReferenceType = DocumentAttributeReferenceTypes.DocumentType,
        Role = (int)DocumentAttributeDocumentRole.DocumentType
    };

    private ReferenceDocumentAttributeSelector DocumentKind { get; } = new ReferenceDocumentAttributeSelector
    {
        ReferenceType = DocumentAttributeReferenceTypes.DocumentKind,
        Role = (int)DocumentAttributeDocumentRole.DocumentKind
    };

    DocumentAttributeValue? IDocumentAttributeValueFactory.CreateFrom(DocumentAttribute attribute, DocumentCreationContext context)
    {
        if (context.Classification is null)
        {
            return null;
        }

        ReferenceDocumentAttributeValue? result =
            TryCreate(attribute, BusinessSegment, context.Classification.BusinessSegmentId) ??
            TryCreate(attribute, DocumentCategory, context.Classification.DocumentCategoryId) ??
            TryCreate(attribute, DocumentType, context.Classification.DocumentTypeId) ??
            TryCreate(attribute, DocumentKind, context.Classification.DocumentKindId);

        return result;
    }

    private static ReferenceDocumentAttributeValue? TryCreate<T>(
        DocumentAttribute attribute,
        ReferenceDocumentAttributeSelector selector,
        Id<T> value)
    {
        if (!selector.IsMatched(attribute))
        {
            return null;
        }

        var valueString = IdConverterTo.ToString(value);

        var result = new ReferenceDocumentAttributeValue(attribute, new[] { valueString });

        return result;
    }
}
