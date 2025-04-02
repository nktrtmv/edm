using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues;
using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Inheritors.Boolean;
using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Inheritors.Date;
using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Inheritors.Number;
using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Inheritors.Reference;
using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Inheritors.String;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.Document.Searcher.Presentation.Abstractions;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Document.Searcher.Presentation.Controllers.SearchDocuments.Converters.Queries.Get.Responses.Documents.AttributesValues;

internal static class GetDocumentsQueryResponseSearchDocumentAttributeValueFromInternalConverter
{
    internal static GetDocumentsQueryResponseSearchDocumentAttributeValue FromInternal(GetDocumentsQueryInternalResponseSearchDocumentAttributeValue attributeValue)
    {
        int registryRoleId = attributeValue.RegistryRoleId;

        var result = new GetDocumentsQueryResponseSearchDocumentAttributeValue
        {
            RegistryRoleId = registryRoleId
        };

        _ = attributeValue switch
        {
            GetDocumentsQueryInternalResponseSearchDocumentBooleanAttributeValue v => ToBoolean(result, v),

            GetDocumentsQueryInternalResponseSearchDocumentDateAttributeValue v => ToDate(result, v),

            GetDocumentsQueryInternalResponseSearchDocumentNumberAttributeValue v => ToNumber(result, v),

            GetDocumentsQueryInternalResponseSearchDocumentReferenceAttributeValue v => ToReference(result, v),

            GetDocumentsQueryInternalResponseSearchDocumentStringAttributeValue v => ToString(result, v),

            _ => throw new ArgumentTypeOutOfRangeException(attributeValue)
        };

        return result;
    }

    private static None ToBoolean(
        GetDocumentsQueryResponseSearchDocumentAttributeValue result,
        GetDocumentsQueryInternalResponseSearchDocumentBooleanAttributeValue attributeValue)
    {
        var asBoolean = new GetDocumentsQueryResponseSearchDocumentBooleanAttributeValue
        {
            Values = { attributeValue.Values }
        };

        result.AsBoolean = asBoolean;

        return default;
    }

    private static None ToDate(
        GetDocumentsQueryResponseSearchDocumentAttributeValue result,
        GetDocumentsQueryInternalResponseSearchDocumentDateAttributeValue attributeValue)
    {
        Timestamp[] values = attributeValue.Values.Select(UtcDateTimeConverterTo.ToTimeStamp).ToArray();

        var asDate = new GetDocumentsQueryResponseSearchDocumentDateAttributeValue
        {
            Values = { values }
        };

        result.AsDate = asDate;

        return default;
    }

    private static None ToNumber(
        GetDocumentsQueryResponseSearchDocumentAttributeValue result,
        GetDocumentsQueryInternalResponseSearchDocumentNumberAttributeValue attributeValue)
    {
        long[] values = attributeValue.Values.Select(NumberConverterTo.ToLong).ToArray();

        var asNumber = new GetDocumentsQueryResponseSearchDocumentNumberAttributeValue
        {
            Values = { values }
        };

        result.AsNumber = asNumber;

        return default;
    }

    private static None ToReference(
        GetDocumentsQueryResponseSearchDocumentAttributeValue result,
        GetDocumentsQueryInternalResponseSearchDocumentReferenceAttributeValue attributeValue)
    {
        var asReference = new GetDocumentsQueryResponseSearchDocumentReferenceAttributeValue
        {
            Values = { attributeValue.Values },
            ReferenceType = attributeValue.ReferenceType
        };

        if (attributeValue.Parents is [_, ..])
        {
            asReference.ParentValues.AddRange(attributeValue.Parents?.Select(ToParent) ?? []);
        }

        result.AsReference = asReference;

        return default;
    }

    private static GetDocumentsQueryResponseSearchDocumentParentReferenceAttributeValue ToParent(
        GetDocumentsQueryInternalResponseSearchDocumentParentReferenceAttributeValue attributeValue)
    {
        var result = new GetDocumentsQueryResponseSearchDocumentParentReferenceAttributeValue
        {
            ReferenceType = attributeValue.ReferenceType,
            Values = { attributeValue.Values }
        };

        return result;
    }

    private static None ToString(
        GetDocumentsQueryResponseSearchDocumentAttributeValue result,
        GetDocumentsQueryInternalResponseSearchDocumentStringAttributeValue attributeValue)
    {
        var asString = new GetDocumentsQueryResponseSearchDocumentStringAttributeValue
        {
            Values = { attributeValue.Values }
        };

        result.AsString = asString;

        return default;
    }
}
