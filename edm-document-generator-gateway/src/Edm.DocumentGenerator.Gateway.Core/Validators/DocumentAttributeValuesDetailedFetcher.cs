using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.Validators;

internal static class DocumentAttributeValuesDetailedFetcher
{
    public static DocumentAttributeValueDetailedDto FetchSingleAttributeValueByDocumentRole(
        IEnumerable<DocumentAttributeValueDetailedDto> attributeValues,
        DocumentAttributeValueDetailedDto.ValueOneofCase attributeType,
        int documentRoleId)
    {
        var result = FetchSingleAttributeValueOrNullByDocumentRole(attributeValues, attributeType, documentRoleId);

        if (result is null)
        {
            throw new ApplicationException(
                $"""
                 Attribute was not found.
                 DocumentRoleId: {documentRoleId}
                 """);
        }

        return result;
    }

    public static DocumentAttributeValueDetailedDto? FetchSingleAttributeValueOrNullByDocumentRole(
        IEnumerable<DocumentAttributeValueDetailedDto> attributeValues,
        DocumentAttributeValueDetailedDto.ValueOneofCase attributeType,
        int documentRoleId)
    {
        var result = attributeValues.SingleOrDefault(v => v.Attribute.Data.DocumentsRoles.Contains(documentRoleId));

        if (result is null)
        {
            return null;
        }

        if (result.ValueCase != attributeType)
        {
            throw new ApplicationException(
                $"""
                 Attribute has incorrect type.
                 AttributeId: {result.Attribute.Data.Id}
                 Display: {result.Attribute.Data.DisplayName}
                 FoundType: {result.ValueCase}
                 RequiredType: {attributeType}
                 """);
        }

        return result;
    }
}
