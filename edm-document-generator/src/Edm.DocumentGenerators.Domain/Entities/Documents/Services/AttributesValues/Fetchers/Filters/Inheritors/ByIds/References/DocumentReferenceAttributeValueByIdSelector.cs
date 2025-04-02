using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters.Inheritors.ByIds.References;

public sealed class DocumentReferenceAttributeValueByIdSelector
    : DocumentAttributeValueByIdSelectorGeneric<ReferenceDocumentAttributeValue, DocumentReferenceAttribute, string>
{
    public DocumentReferenceAttributeValueByIdSelector(Id<DocumentAttribute> id, string? referenceType) : base(id)
    {
        ReferenceType = referenceType;
    }

    private string? ReferenceType { get; }

    protected override bool TypeIsMatched(DocumentReferenceAttribute attribute)
    {
        if (ReferenceType is null)
        {
            return true;
        }

        var referenceType = MetadataConverterTo.ToString(attribute.ReferenceType);

        bool result = referenceType == ReferenceType;

        return result;
    }
}
