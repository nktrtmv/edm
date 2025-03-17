using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts.Types.SearchKinds;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Contracts;

public sealed record DocumentReferenceTypeResponseInternal(
    string? DomainId,
    Id<DocumentReferenceTypeId> ReferenceTypeId,
    string DisplayName,
    Id<DocumentReferenceTypeId>[] ParentIds,
    DocumentReferenceSearchKindInternal SearchKind,
    ConcurrencyToken<DocumentReferenceTypeResponseInternal> ConcurrencyToken);
