using MediatR;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetAll.Contracts;

public sealed record GetAllDocumentReferenceTypesQueryInternal(string DomainId, string? Search, int Skip, int Limit)
    : IRequest<GetAllDocumentReferenceTypesQueryResponseInternal>;
