using Edm.Document.Classifier.Application.Contracts.Markers;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentReferences.Values.Commands.Update.Contracts;

public sealed record UpdateDocumentReferenceValueCommandInternal(
    Id<UserInternal> CurrentUserId,
    Id<DocumentReferenceTypeId> ReferenceType,
    Id<ReferenceValueInternal> Id,
    Id<ReferenceValueInternal>? NewId,
    string DisplayValue,
    string DisplaySubValue,
    bool IsHidden,
    ConcurrencyToken<ReferenceValueInternal> ConcurrencyToken) : IRequest<UpdateDocumentReferenceValueCommandResponseInternal>;
