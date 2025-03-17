using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.DocumentsRoles;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters.Inheritors.ByRoles.Inheritors.References;

public sealed class DocumentReferenceAttributeValueSelector
    : DocumentAttributeValueByRoleSelectorGeneric<ReferenceDocumentAttributeValue, DocumentReferenceAttribute, string>
{
    public DocumentReferenceAttributeValueSelector(DocumentAttributeDocumentRole role, string referenceType, params string[] displayNames) : base(role, displayNames)
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

    public override string ToString()
    {
        var baseMessage = base.ToString();

        var thisMessage = $"ReferenceType: {ReferenceType}";

        string result = string.Join(", ", baseMessage, thisMessage);

        return result;
    }
}
