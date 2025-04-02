using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.Get.Contracts;

public sealed record GetDocumentReferenceTypeQueryInternal(
    Id<DocumentReferenceTypeId> ReferenceType,
    string DomainId) : IRequest<GetDocumentReferenceTypeQueryResponseInternal>;
