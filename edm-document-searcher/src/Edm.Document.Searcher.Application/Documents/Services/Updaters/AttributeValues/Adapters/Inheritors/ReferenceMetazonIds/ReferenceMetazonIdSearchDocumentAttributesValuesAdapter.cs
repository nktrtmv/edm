using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Numbers;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.References;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.References.Types;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Adapters.Abstractions.SynchronousSingle;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.ValueObjects.RegistryRoles.Ids;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.Document.Searcher.GenericSubdomain.Extensions.Types;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Adapters.Inheritors.
    ReferenceMetazonIds;

internal sealed class ReferenceMetazonIdSearchDocumentAttributesValuesAdapter : SynchronousSingleSearchDocumentAttributesValuesAdapter
{
    protected override SearchDocumentAttributeValueInternal Adapt(SearchDocumentAttributeValueInternal attributeValue)
    {
        if (attributeValue.RegistryRole.Id is not SearchDocumentRegistryRoleId.MetazonId)
        {
            return attributeValue;
        }

        if (attributeValue is SearchDocumentNumberAttributeValueInternal)
        {
            return attributeValue;
        }

        SearchDocumentReferenceAttributeValueInternal referenceAttributeValue =
            TypeCasterTo<SearchDocumentReferenceAttributeValueInternal>.CastRequired(attributeValue);

        Validate(referenceAttributeValue.ReferenceType);

        Number<SearchDocumentNumberAttributeValueInternal>[] values = referenceAttributeValue.Values
            .Select(AdjustValue)
            .ToArray();

        var result = new SearchDocumentNumberAttributeValueInternal(attributeValue.RegistryRole, values, 0);

        return result;
    }

    private static Number<SearchDocumentNumberAttributeValueInternal> AdjustValue(string value)
    {
        Number<SearchDocumentNumberAttributeValueInternal> result =
            NumberConverterFrom<SearchDocumentNumberAttributeValueInternal>.FromString(value);

        return result;
    }

    private static void Validate(string referenceType)
    {
        None _ = referenceType switch
        {
            SearchDocumentReferenceAttributeValueTypeInternal.Contracts => default,
            _ => throw new ArgumentTypeOutOfRangeException(referenceType)
        };
    }
}
