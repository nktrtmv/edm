using MediatR;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetNewReferenceTypeId.Contracts;

public sealed record GetNewReferenceTypeIdQueryInternal(): IRequest<GetNewReferenceTypeIdQueryResponseInternal>;
