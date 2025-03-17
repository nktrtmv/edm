using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.References.Types.Contracts;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetReferencesTypes.Converters.SearchConditions;

internal static class ReferenceTypeBffSearchConditionConverter
{
    internal static ReferenceTypeBffSearchCondition FromDto(GetTypesQueryResponseReferenceSearchConditionType searchCondition)
    {
        var result = searchCondition switch
        {
            GetTypesQueryResponseReferenceSearchConditionType.FixedList => ReferenceTypeBffSearchCondition.FixedList,
            GetTypesQueryResponseReferenceSearchConditionType.Search => ReferenceTypeBffSearchCondition.Search,
            _ => throw new ArgumentTypeOutOfRangeException(searchCondition)
        };

        return result;
    }
}
