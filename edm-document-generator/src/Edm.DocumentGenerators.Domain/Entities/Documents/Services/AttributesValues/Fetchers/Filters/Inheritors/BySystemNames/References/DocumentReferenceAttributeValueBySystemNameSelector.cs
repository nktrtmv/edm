using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters.Inheritors.BySystemNames.References;

public sealed class DocumentReferenceAttributeValueBySystemNameSelector
    : DocumentAttributeValueBySystemSelectorGeneric<ReferenceDocumentAttributeValue, DocumentReferenceAttribute, string>
{
    public DocumentReferenceAttributeValueBySystemNameSelector(string systemName, string referenceType) : base(systemName)
    {
        ReferenceType = referenceType;
    }

    private string ReferenceType { get; }

    protected override bool TypeIsMatched(DocumentReferenceAttribute attribute)
    {
        var referenceType = MetadataConverterTo.ToString(attribute.ReferenceType);

        bool result = referenceType == ReferenceType;

        return result;
    }
}
