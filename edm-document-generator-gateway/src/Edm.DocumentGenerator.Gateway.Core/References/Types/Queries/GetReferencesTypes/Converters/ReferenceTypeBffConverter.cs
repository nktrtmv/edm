using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.References.GetReferencesTypes.Converters.ReferenceKind;
using Edm.DocumentGenerator.Gateway.Core.References.Types.Contracts;
using Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetReferencesTypes.Converters.SearchConditions;

namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetReferencesTypes.Converters;

internal static class ReferenceTypeBffConverter
{
    public static ReferenceTypeBff FromDto(GetTypesQueryResponseReference reference)
    {
        var searchCondition = ReferenceTypeBffSearchConditionConverter.FromDto(reference.SearchConditionType);

        var result = new ReferenceTypeBff
        {
            ReferenceType = reference.ReferenceType,
            ReferenceTypes = reference.ParentReferencesTypes.ToArray(),
            SearchCondition = searchCondition,
            ReferenceKind = ReferenceTypeBffReferenceKindConverter.FromDto(reference.ReferenceKind),
            DisplayName = reference.DisplayName
        };

        return result;
    }

    public static ReferenceTypeBff FromDto(GetDocumentReferenceType reference)
    {
        var searchCondition = ReferenceTypeBffSearchConditionConverter.FromDto(reference.SearchConditionType);

        var result = new ReferenceTypeBff
        {
            ReferenceType = reference.ReferenceType,
            ReferenceTypes = reference.ParentReferencesTypes.ToArray(),
            SearchCondition = searchCondition,
            ReferenceKind = ReferenceTypeBffReferenceKind.None,
            DisplayName = reference.DisplayName,
            ConcurrencyToken = reference.ConcurrencyToken
        };

        return result;
    }
}
