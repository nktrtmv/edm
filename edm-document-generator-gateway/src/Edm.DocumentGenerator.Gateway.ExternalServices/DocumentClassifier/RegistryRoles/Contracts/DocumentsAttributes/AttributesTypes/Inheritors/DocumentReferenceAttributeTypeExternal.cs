namespace Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.DocumentsAttributes.AttributesTypes.Inheritors;

public sealed class DocumentReferenceAttributeTypeExternal : DocumentAttributeTypeExternal
{
    public DocumentReferenceAttributeTypeExternal(string referenceType)
    {
        ReferenceType = referenceType;
    }

    public string ReferenceType { get; }
}
