using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.Get.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Contracts.TypesIds;

namespace Edm.Document.Classifier.Presentation.Controllers.References.Converters.Types.Queries.Get;

internal static class GetDocumentReferenceTypeQueryConverter
{
    public static GetDocumentReferenceTypeQueryInternal ToInternal(GetDocumentReferenceTypeQuery query)
    {
        Id<DocumentReferenceTypeId> referenceType = ReferenceTypeIdConverter.FromDto(query.ReferenceType);

        var result = new GetDocumentReferenceTypeQueryInternal(referenceType, query.DomainId);

        return result;
    }
}
