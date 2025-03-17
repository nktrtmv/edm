using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors.Classifications.Services;

public static class SearchParametersFilterFactory
{
    public static Id<T>[] CreateSearchIdsFilter<T>(DocumentReferenceSearchParamsInternal searchParameters)
    {
        Id<T>[] result = searchParameters.Ids.Select(IdConverterFrom<T>.FromString).ToArray();

        return result;
    }

    public static HashSet<Id<T>> CreateParentReferenceIdsFilter<T>(DocumentReferenceSearchParamsInternal searchParameters, DocumentReferenceTypeId referenceTypeId)
    {
        int referenceType = (int)referenceTypeId;

        var result = searchParameters.Key.ParentValues
            .Where(v => int.Parse(v.ReferenceTypeId.Value) == referenceType)
            .SelectMany(v => v.Ids)
            .Select(IdConverterFrom<T>.FromString)
            .ToHashSet();

        return result;
    }
}
