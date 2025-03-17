using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams.Keys;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams.Keys.ParentValues;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Contracts.TypesIds;
using Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Queries.GetReferenceValuesSearch.Contracts.ParentReferenceTypeId;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Queries.GetReferenceValuesSearch;

internal static class GetReferenceValuesSearchQueryConverter
{
    internal static SearchValuesDocumentReferencesQueryInternal ToInternal(GetReferenceValuesSearchQuery query)
    {
        Id<DocumentReferenceTypeId> referenceTypeId = ReferenceTypeIdConverter.FromDto(query.ReferenceType);

        DocumentReferenceParentValuesInternal[] parentValues =
            query.ParentReferenceTypeIdToValues.Select(ParentReferenceTypeIdConverter.ToInternal).ToArray();

        var key = new DocumentReferenceKeyInternal(referenceTypeId, parentValues, query.TemplateId);

        string[] ids = query.Ids.ToArray();
        var searchParams = new DocumentReferenceSearchParamsInternal(key, ids, query.Query, query.Skip, query.Limit);

        var result = new SearchValuesDocumentReferencesQueryInternal(searchParams);

        return result;
    }
}
