using Edm.Document.Classifier.Application.Contracts.Markers;
using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts.Types;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Commands.Update.Contracts;

public sealed record UpdateDocumentReferenceTypeCommandInternal(
    Id<DocumentReferenceTypeId> ReferenceType,
    string DomainId,
    Id<UserInternal> CurrentUserId,
    string DisplayName,
    Id<DocumentReferenceTypeId>[] ParentIds,
    ConcurrencyToken<DocumentReferenceTypeInternal> ConcurrencyToken) : IRequest<UpdateDocumentReferenceTypeCommandResponseInternal>;
