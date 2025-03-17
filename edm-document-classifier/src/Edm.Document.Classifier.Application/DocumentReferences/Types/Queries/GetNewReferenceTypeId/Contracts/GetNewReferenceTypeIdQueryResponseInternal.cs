using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetNewReferenceTypeId.Contracts;

public sealed record GetNewReferenceTypeIdQueryResponseInternal(Id<DocumentReferenceTypeId> ReferenceTypeId);
