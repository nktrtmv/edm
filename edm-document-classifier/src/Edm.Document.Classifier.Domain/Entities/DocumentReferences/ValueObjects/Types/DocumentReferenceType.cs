using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.ReferenceKind;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.SearchKinds;

namespace Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types;

public sealed record DocumentReferenceType(
    DocumentReferenceTypeId Id,
    DocumentReferenceSearchKind SearchKind,
    DocumentReferenceKind ReferenceKind,
    string DisplayName,
    params DocumentReferenceTypeId[] ParentIds);
