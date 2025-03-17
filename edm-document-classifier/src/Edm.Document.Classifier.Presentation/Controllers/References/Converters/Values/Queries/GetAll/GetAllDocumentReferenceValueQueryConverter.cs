using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.GetAll.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Contracts.TypesIds;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Queries.GetAll;

internal static class GetAllDocumentReferenceValuesQueryConverter
{
    public static GetAllDocumentReferenceValuesQueryInternal ToInternal(GetAllDocumentReferenceValuesQuery query)
    {
        Id<DocumentReferenceTypeId> referenceType = ReferenceTypeIdConverter.FromDto(query.ReferenceType);

        var result = new GetAllDocumentReferenceValuesQueryInternal(referenceType, query.Search, query.Skip, query.Limit);

        return result;
    }
}
