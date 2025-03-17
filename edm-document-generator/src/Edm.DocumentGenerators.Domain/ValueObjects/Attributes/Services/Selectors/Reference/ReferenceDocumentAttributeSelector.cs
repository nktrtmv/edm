using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Services.Selectors.Reference;

internal sealed record ReferenceDocumentAttributeSelector : DocumentAttributeSelector<DocumentReferenceAttribute>
{
    internal required string ReferenceType { get; init; }

    protected override bool AttributeTypeMatched(DocumentReferenceAttribute attribute)
    {
        var referenceType = MetadataConverterTo.ToString(attribute.ReferenceType);

        bool result = referenceType == ReferenceType;

        return result;
    }

    protected override IEnumerable<string?> GetMarkers()
    {
        var referenceType = $"ReferenceType: {ReferenceType}";

        IEnumerable<string?> result = base
            .GetMarkers()
            .Append(referenceType);

        return result;
    }
}
