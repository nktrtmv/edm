using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts.Types;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Contracts.TypesIds;
using Edm.Document.Classifier.Presentation.Controllers.References.Converters.Types.Queries.GetTypes.Contracts.References.SearchConditionTypes;
using Edm.Document.Classifier.Presentation.Controllers.References.Converters.Queries.GetTypes.Contracts.References.ReferenceKind;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Types.Queries.GetTypes.Contracts.References;

internal static class GetTypesQueryResponseReferenceConverter
{
    internal static GetTypesQueryResponseReference FromInternal(DocumentReferenceTypeInternal type)
    {
        string referenceType = ReferenceTypeIdConverter.ToDto(type.Id);

        string[] parentReferencesTypes = type.ParentIds.Select(ReferenceTypeIdConverter.ToDto).ToArray();

        GetTypesQueryResponseReferenceSearchConditionType searchConditionType =
            GetTypesQueryResponseReferenceSearchConditionTypeConverter.FromInternal(type.SearchKind);

        GetTypesQueryResponseReferenceKind referenceKind =
            GetTypesQueryResponseReferenceKindConverter.FromInternal(type.ReferenceKind);

        var result = new GetTypesQueryResponseReference
        {
            ReferenceType = referenceType,
            ParentReferencesTypes = { parentReferencesTypes },
            DisplayName = type.DisplayName,
            SearchConditionType = searchConditionType,
            ReferenceKind = referenceKind
        };

        return result;
    }
}
