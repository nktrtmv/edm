using Edm.Document.Classifier.Application.DocumentReferences.Types.Contracts;
using Edm.Document.Classifier.GenericSubdomain.Tokens.Concurrency;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Contracts.TypesIds;
using Edm.Document.Classifier.Presentation.Controllers.References.Converters.Types.Queries.GetTypes.Contracts.References.SearchConditionTypes;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Types.Queries.Get.DocumentReferenceType;

internal static class GetDocumentReferenceTypeConverter
{
    public static GetDocumentReferenceType FromInternal(DocumentReferenceTypeResponseInternal type)
    {
        string referenceType = ReferenceTypeIdConverter.ToDto(type.ReferenceTypeId);

        string[] parentReferencesTypes = type.ParentIds.Select(ReferenceTypeIdConverter.ToDto).ToArray();

        string concurrencyToken = ConcurrencyTokenConverterTo.ToString(type.ConcurrencyToken);

        GetTypesQueryResponseReferenceSearchConditionType searchConditionType =
            GetTypesQueryResponseReferenceSearchConditionTypeConverter.FromInternal(type.SearchKind);

        var result = new GetDocumentReferenceType
        {
            ReferenceType = referenceType,
            DomainId = type.DomainId,
            ParentReferencesTypes = { parentReferencesTypes },
            DisplayName = type.DisplayName,
            SearchConditionType = searchConditionType,
            ConcurrencyToken = concurrencyToken
        };

        return result;
    }
}
