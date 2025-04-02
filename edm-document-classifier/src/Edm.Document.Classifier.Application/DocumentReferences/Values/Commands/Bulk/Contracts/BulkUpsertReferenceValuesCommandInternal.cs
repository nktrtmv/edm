using Edm.Document.Classifier.Application.DocumentReferences.Values.Commands.Bulk.Contracts.Values;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentReferences.Values.Commands.Bulk.Contracts;

public sealed record BulkUpsertReferenceValuesCommandInternal(
    string DomainId,
    Id<DocumentReferenceTypeId> ReferenceType,
    BulkUpsertReferenceValueInternal[] Values,
    string CurrentUserId)
    : IRequest<BulkUpsertReferenceValuesCommandResponseInternal>;
