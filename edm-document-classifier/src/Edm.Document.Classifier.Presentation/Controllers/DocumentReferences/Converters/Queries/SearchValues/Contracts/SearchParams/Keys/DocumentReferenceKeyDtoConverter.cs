using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams.Keys;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams.Keys.ParentValues;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Contracts.TypesIds;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Queries.SearchValues.Contracts.SearchParams.Keys.ParentValues;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Queries.SearchValues.Contracts.SearchParams.Keys;

internal static class DocumentReferenceKeyDtoConverter
{
    internal static DocumentReferenceKeyInternal ToInternal(DocumentReferenceKeyDto key)
    {
        Id<DocumentReferenceTypeId> referenceTypeId = ReferenceTypeIdConverter.FromDto(key.ReferenceTypeId);

        DocumentReferenceParentValuesInternal[] parentValues =
            key.ParentValues.Select(DocumentReferenceParentValuesDtoConverter.ToInternal).ToArray();

        var result = new DocumentReferenceKeyInternal(referenceTypeId, parentValues, key.TemplateId);

        return result;
    }
}
