using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.Get.Contracts;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.Values;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Contracts.TypesIds;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Values.Queries.Get;

internal static class GetDocumentReferenceValueQueryConverter
{
    public static GetDocumentReferenceValueQueryInternal ToInternal(GetDocumentReferenceValueQuery query)
    {
        Id<DocumentReferenceTypeId> referenceType = ReferenceTypeIdConverter.FromDto(query.ReferenceType);

        Id<DocumentReferenceValueInternal> id = IdConverterFrom<DocumentReferenceValueInternal>.FromString(query.Id);

        var result = new GetDocumentReferenceValueQueryInternal(referenceType, id);

        return result;
    }
}
