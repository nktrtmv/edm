using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.Values;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.Get.Contracts;

public sealed record GetDocumentReferenceValueQueryInternal(
    Id<DocumentReferenceTypeId> ReferenceType,
    Id<DocumentReferenceValueInternal> Id) : IRequest<GetDocumentReferenceValueQueryResponseInternal>;
