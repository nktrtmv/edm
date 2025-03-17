using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams.Keys.ParentValues;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Contracts.TypesIds;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Queries.GetReferenceValuesSearch.Contracts.ParentReferenceTypeId;

internal static class ParentReferenceTypeIdConverter
{
    internal static DocumentReferenceParentValuesInternal ToInternal(Abstractions.ParentReferenceTypeId parentReferenceTypeId)
    {
        Id<DocumentReferenceTypeId> referenceTypeId = ReferenceTypeIdConverter.FromDto(parentReferenceTypeId.ReferenceType);

        string[] ids = parentReferenceTypeId.Ids.ToArray();

        var result = new DocumentReferenceParentValuesInternal(referenceTypeId, ids);

        return result;
    }
}
