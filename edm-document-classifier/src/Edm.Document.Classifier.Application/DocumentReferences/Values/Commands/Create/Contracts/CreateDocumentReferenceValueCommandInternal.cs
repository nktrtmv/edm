using Edm.Document.Classifier.Application.Contracts.Markers;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentReferences.Values.Commands.Create.Contracts;

public sealed record CreateDocumentReferenceValueCommandInternal(
    Id<UserInternal> CurrentUserId,
    Id<DocumentReferenceTypeId> ReferenceType,
    Id<ReferenceValueInternal>? Id,
    string DomainId,
    string DisplayValue,
    string DisplaySubValue,
    bool IsHidden
    ) : IRequest<CreateDocumentReferenceValueCommandResponseInternal>;
