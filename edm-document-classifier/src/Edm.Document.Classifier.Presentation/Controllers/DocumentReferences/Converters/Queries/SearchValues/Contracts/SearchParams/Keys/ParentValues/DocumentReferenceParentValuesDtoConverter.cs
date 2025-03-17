using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams.Keys.ParentValues;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Contracts.TypesIds;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Queries.SearchValues.Contracts.SearchParams.Keys.ParentValues;

internal static class DocumentReferenceParentValuesDtoConverter
{
    internal static DocumentReferenceParentValuesInternal ToInternal(DocumentReferenceParentValuesDto parentValues)
    {
        Id<DocumentReferenceTypeId> referenceTypeId = ReferenceTypeIdConverter.FromDto(parentValues.ReferenceTypeId);

        string[] ids = parentValues.Ids.ToArray();

        var result = new DocumentReferenceParentValuesInternal(referenceTypeId, ids);

        return result;
    }
}
