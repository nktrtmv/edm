using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.GetAll.Contracts;

public sealed record GetAllDocumentReferenceValuesQueryInternal(Id<DocumentReferenceTypeId> ReferenceType, string? Search, int Skip, int Limit)
    : IRequest<GetAllDocumentReferenceValuesQueryResponseInternal>;
