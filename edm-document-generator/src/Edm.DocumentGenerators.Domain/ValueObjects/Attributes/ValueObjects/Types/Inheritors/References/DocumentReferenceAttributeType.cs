using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.Types.Inheritors.References;

public sealed class DocumentReferenceAttributeType : DocumentAttributeType
{
    public DocumentReferenceAttributeType(Metadata<DocumentReferenceAttributeType> referenceType)
    {
        ReferenceType = referenceType;
    }

    public Metadata<DocumentReferenceAttributeType> ReferenceType { get; }
}
