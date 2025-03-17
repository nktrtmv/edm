using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.SearchKinds;

namespace Edm.Document.Classifier.Domain.Entities.DocumentReferences.Factories;

public interface IReferenceServicesProvider
{
    Dictionary<DocumentReferenceTypeId, DocumentReferenceSearchKind> BuildReferencesBySearchType();
}
