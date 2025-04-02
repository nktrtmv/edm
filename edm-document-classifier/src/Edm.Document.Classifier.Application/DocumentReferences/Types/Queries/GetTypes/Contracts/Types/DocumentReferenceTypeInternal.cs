using Edm.Document.Classifier.Application.DocumentReferences.Queries.GetTypes.Contracts.Types.ReferenceKind;
using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts.Types.SearchKinds;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts.Types;

public sealed record DocumentReferenceTypeInternal(
    Id<DocumentReferenceTypeId> Id,
    DocumentReferenceSearchKindInternal SearchKind,
    DocumentReferenceKindInternal ReferenceKind,
    string DisplayName,
    Id<DocumentReferenceTypeId>[] ParentIds);
