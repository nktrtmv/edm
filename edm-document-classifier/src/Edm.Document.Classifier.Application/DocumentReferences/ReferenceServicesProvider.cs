using Edm.Document.Classifier.Application.DocumentReferences.Services;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.Factories;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.SearchKinds;

namespace Edm.Document.Classifier.Application.DocumentReferences;

public sealed class ReferenceServicesProvider(IEnumerable<DocumentReferenceService> references) : IReferenceServicesProvider
{
    public Dictionary<DocumentReferenceTypeId, DocumentReferenceSearchKind> BuildReferencesBySearchType()
    {
        var result = references
            .Select(x => x.Type)
            .ToDictionary(x => x.Id, x => x.SearchKind);

        return result;
    }
}
