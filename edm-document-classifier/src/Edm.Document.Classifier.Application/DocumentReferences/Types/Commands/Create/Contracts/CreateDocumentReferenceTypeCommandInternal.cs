using Edm.Document.Classifier.Application.Contracts.Markers;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Commands.Create.Contracts;

public sealed record CreateDocumentReferenceTypeCommandInternal(
    string DomainId,
    Id<DocumentReferenceTypeId> ReferenceType,
    Id<UserInternal> CurrentUserId,
    string DisplayName,
    Id<DocumentReferenceTypeId>[] ParentIds
    ) : IRequest<CreateDocumentReferenceTypeCommandResponseInternal>;
