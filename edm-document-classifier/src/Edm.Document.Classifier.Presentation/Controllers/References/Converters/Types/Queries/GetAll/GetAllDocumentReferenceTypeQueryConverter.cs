using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetAll.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Types.Queries.GetAll;

internal static class GetAllDocumentReferenceTypesQueryConverter
{
    public static GetAllDocumentReferenceTypesQueryInternal ToInternal(GetAllDocumentReferenceTypesQuery query)
    {
        var result = new GetAllDocumentReferenceTypesQueryInternal(query.DomainId, query.Search, query.Skip, query.Limit);

        return result;
    }
}
