using Edm.Document.Searcher.ExternalServices.Documents.Contracts;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Inheritors.Reference;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Reference;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.String;
using Edm.Document.Searcher.GenericSubdomain.Extensions.Types;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Services;

internal static class DocumentAttributeValuesFetcher
{
    internal static DocumentReferenceAttributeValueExternal? FetchReferenceByRegistryRole(DocumentExternal document, int registryRoleId, string referenceTypeId)
    {
        var result =
            document.AttributesValues.FirstOrDefault(a => a.Attribute.Data.RegistryRolesIds.Contains(registryRoleId)) as DocumentReferenceAttributeValueExternal;

        if (result is null)
        {
            return null;
        }

        DocumentReferenceAttributeExternal referenceAttribute = TypeCasterTo<DocumentReferenceAttributeExternal>.CastRequired(result.Attribute);

        if (referenceAttribute.ReferenceType != referenceTypeId)
        {
            return null;
        }

        return result;
    }

    internal static DocumentStringAttributeValueExternal? FetchStringAttributeBySystemName(DocumentExternal document, string systemName)
    {
        DocumentAttributeValueExternal? attribute = FetchAttributeBySystemName(document, systemName);

        if (attribute == null)
        {
            return null;
        }

        DocumentStringAttributeValueExternal result =
            TypeCasterTo<DocumentStringAttributeValueExternal>.CastRequired(attribute);

        return result;
    }

    internal static TValue? FetchSingleOrDefaultAttributeValueBySystemName<TValue>(DocumentExternal document, string systemName) where TValue: class
    {
        DocumentAttributeValueExternal? attributeValue = document.AttributesValues
            .SingleOrDefault(x => x.Attribute.Data.SystemName == systemName);

        if (attributeValue is null)
        {
            return null;
        }

        DocumentAttributeValueExternalGeneric<TValue> specificAttributeValue =
            TypeCasterTo<DocumentAttributeValueExternalGeneric<TValue>>.CastRequired(attributeValue);

        TValue? result = specificAttributeValue.Values.SingleOrDefault();

        return result;
    }

    private static DocumentAttributeValueExternal? FetchAttributeBySystemName(DocumentExternal document, string systemName)
    {
        DocumentAttributeValueExternal? result = document.AttributesValues
            .FirstOrDefault(x => x.Attribute.Data.SystemName == systemName);

        return result;
    }
}
